using YoutubeExplode.Videos.Streams;
using NAudio.Lame;
using NAudio.Wave;
using YoutubeExplode;

namespace YouTubeToMp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PopulateBitrateOptions();
            // Set default button for pasting
            this.AcceptButton = btnConvert;
        }

        private void PopulateBitrateOptions()
        {
            cmbBitrate.Items.Add("128 kbps");
            cmbBitrate.Items.Add("192 kbps");
            cmbBitrate.Items.Add("320 kbps");
            cmbBitrate.SelectedIndex = 0;
        }

        private void txtUrl_TextChanged(object sender, EventArgs e)
        {
            // Validate the URL
            string url = txtUrl.Text;
            if (!url.StartsWith("http", StringComparison.OrdinalIgnoreCase))
            {
                lblStatus.Text = "Please enter a valid URL that starts with 'http'.";
                btnConvert.Enabled = false;
            }
            else
            {
                lblStatus.Text = string.Empty;
                btnConvert.Enabled = true;
            }
        }

        private async void btnConvert_Click(object sender, EventArgs e)
        {
            string videoUrl = txtUrl.Text;
            lblStatus.Text = "Downloading...";
            btnConvert.Enabled = false;

            try
            {
                var youtube = new YoutubeClient();
                var video = await youtube.Videos.GetAsync(videoUrl);
                var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video.Id);
                var streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();

                string videoTitle = ReplaceInvalidFileNameChars(video.Title).Replace("_", " ");
                string tempVideoFilePath = Path.Combine(Path.GetTempPath(), "video.mp4");

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "MP3 Files (*.mp3)|*.mp3",
                    FileName = $"{videoTitle}.mp3",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic),
                    Title = "Save MP3 File"
                };

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    lblStatus.Text = "Save operation was canceled.";
                    btnConvert.Enabled = true;
                    return;
                }

                string outputMp3FilePath = saveFileDialog.FileName;

                // Asynchronously download the video
                await Task.Run(async () =>
                {
                    using (var outputFile = new FileStream(tempVideoFilePath, FileMode.Create, FileAccess.Write))
                    using (var inputStream = await youtube.Videos.Streams.GetAsync(streamInfo))
                    {
                        await inputStream.CopyToAsync(outputFile);
                    }
                });

                lblStatus.Text = "Converting...";

                int bitrate = GetSelectedBitrate();

                // Asynchronously convert the video to MP3
                await Task.Run(() =>
                {
                    using (var reader = new MediaFoundationReader(tempVideoFilePath))
                    using (var writer = new LameMP3FileWriter(outputMp3FilePath, reader.WaveFormat, bitrate))
                    {
                        reader.CopyTo(writer);
                    }

                    // Clean up temporary file
                    File.Delete(tempVideoFilePath);
                });

                lblStatus.Text = "Conversion complete!";
                MessageBox.Show($"Conversion complete! MP3 saved to: {outputMp3FilePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error: {ex.Message}";
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnConvert.Enabled = true;
            }
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                txtUrl.Text = Clipboard.GetText();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.V))
            {
                if (Clipboard.ContainsText())
                {
                    txtUrl.Text = Clipboard.GetText();
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private int GetSelectedBitrate()
        {
            var selectedItem = cmbBitrate.SelectedItem?.ToString();
            if (selectedItem == null)
            {
                return 128; // Default to 128 kbps
            }

            return selectedItem switch
            {
                "128 kbps" => 128,
                "192 kbps" => 192,
                "320 kbps" => 320,
                _ => 128 // Default to 128 kbps if the selected item doesn't match any case
            };
        }

        private string ReplaceInvalidFileNameChars(string fileName, char replacement = '_')
        {
            return string.Concat(fileName.Split(Path.GetInvalidFileNameChars())).Replace(" ", replacement.ToString());
        }
    }
}