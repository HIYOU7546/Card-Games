using System;
using NAudio.Wave;

namespace Audio
{
    public class PlayAudio
    {
        /// <summary>
        /// Plays A sound file without stopping the main thread.
        /// </summary>
        /// <param name="soundName">The name of the sound file to play.</param>
        /// <param name="stopLength">The length of time (in milliseconds) to play the sound before stopping it. If 0, the sound plays until completion. Defualt is 0</param>
        /// <returns>A Task that completes when playback is finished.</returns>
        public static Task Playsound(string soundName, int stopLength = 0)
        {
            // TaskCompletionSource is used to signal when playback is truly complete.
            var tcs = new TaskCompletionSource<bool>();

            try
            {
                using (var audioFile = new AudioFileReader(soundName))
                using (var outputDevice = new WaveOutEvent())
                {
                    // Subscribe to the PlaybackStopped event
                    outputDevice.PlaybackStopped += (sender, e) =>
                    {
                        // Signal the TaskCompletionSource when playback stops
                        tcs.SetResult(true);
                        // Dispose the device and file when done
                        outputDevice.Dispose();
                        audioFile.Dispose();
                    };

                    outputDevice.Init(audioFile);
                    outputDevice.Play();
                    if (stopLength > 0)
                    {
                        // If a stop length is specified, create a timer to stop playback
                        var timer = new System.Timers.Timer(stopLength);
                        timer.Elapsed += (s, e) =>
                        {
                            outputDevice.Stop();
                            timer.Dispose();
                        };
                        timer.AutoReset = false; // Ensure it only runs once
                        timer.Start();
                    }

                    // Wait for the TaskCompletionSource to be set
                    return tcs.Task;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Handle exceptions if the file isn't found or is invalid
                tcs.SetException(ex);
                return tcs.Task;
            }
        }

        public struct AudioFile
        {
            public string FileLocation { get; set; }
            public int AudioLength { get; set; }

            public AudioFile(string FileLocation)
            {
                this.FileLocation = FileLocation;
                using (AudioFileReader audioFileReader = new AudioFileReader(FileLocation))
                    AudioLength = (int)audioFileReader.TotalTime.TotalMilliseconds;
            }
        }
    }
}