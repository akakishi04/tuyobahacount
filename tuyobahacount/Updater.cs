using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json.Linq;

namespace tuyobahacount
{
    public class Updater
    {

        public static async Task<string> GetLatestReleaseInfo(string repoUrl)
        {
            using (var client = new HttpClient())
            {
                // GitHub APIを使用する際にはUser-Agentヘッダーを設定する
                client.DefaultRequestHeaders.UserAgent.ParseAdd("request");

                var response = await client.GetAsync(repoUrl);
                if (!response.IsSuccessStatusCode)
                {
                    // エラーハンドリング
                    throw new InvalidOperationException($"APIリクエストに失敗しました。ステータスコード: {response.StatusCode}");
                }
                return await response.Content.ReadAsStringAsync();
            }
        }
        public static string GetDownloadUrl(string json)
        {
            var jObject = JObject.Parse(json);
            return jObject["assets"][0]["browser_download_url"].ToString();
        }

        public static async Task DownloadFileAsync(string downloadUrl, string localPath)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(downloadUrl);
                using (var fs = new FileStream(localPath, FileMode.Create)) // FileMode.CreateNewからFileMode.Createに変更
                {
                    await response.Content.CopyToAsync(fs);
                }
            }
        }

        public static void UpdateApplication(string zipPath, string applicationDirectory, string applicationPath)
        {
            // ZIPファイルから特定のフォルダを解凍
            ExtractFolderFromZip(zipPath, applicationDirectory);

            // アプリケーションを再起動
            Process.Start(applicationPath);
        }
        public static Version GetCurrentVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version;
        }

        public static Version GetLatestReleaseVersion(string json)
        {
            var jObject = JObject.Parse(json);
            string tagName = jObject["tag_name"].ToString();
            return Version.Parse(tagName);
        }

        public async Task<bool> CheckForUpdates()
        {


            var releaseInfo = await GetLatestReleaseInfo("https://api.github.com/repos/akakishi04/tuyobahacount/releases/latest");
            var downloadUrl = GetDownloadUrl(releaseInfo);

            var currentVersion = GetCurrentVersion();
            var latestVersion = GetLatestReleaseVersion(releaseInfo);

            if (latestVersion > currentVersion)
            {
                var result = MessageBox.Show(
                    $"新しいバージョン {latestVersion} が利用可能です。現在のバージョン: {currentVersion}\n今すぐアップデートしますか？",
                    "アップデートの確認",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Information);

                if (result == MessageBoxResult.Yes)
                {
                    string zipPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "download.zip");
                    string updaterPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Updater.exe");
                    string extractPath = AppDomain.CurrentDomain.BaseDirectory;
                    string appPath = Process.GetCurrentProcess().MainModule.FileName;
                    int processId = Process.GetCurrentProcess().Id;

                    // ZIPファイルをダウンロード
                    await DownloadFileAsync(downloadUrl, zipPath);
                    string arguments = $"\"{zipPath}\" \"{extractPath}\" \"{appPath}\" {processId}";
                    // アップデーターを起動してメインアプリケーションを終了
                    var process = Process.Start(updaterPath,arguments);


                    if (process != null)
                    {
                        // プロセスが正常に起動した
                        Console.WriteLine($"Updaterが起動しました。プロセスID: {process.Id}");
                    }
                    else
                    {
                        // プロセスの起動に失敗した
                        Console.WriteLine("Updaterの起動に失敗しました。");
                    }
                    Application.Current.Shutdown();

                    return true;
                }
            }
            return false;
        }


        public static void ExtractFolderFromZip(string zipPath, string extractPath)
        {
            string folderName = "TuyobahaCount"; // 展開したいフォルダ名

            using (ZipArchive archive = ZipFile.OpenRead(zipPath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.StartsWith(folderName + "/", StringComparison.OrdinalIgnoreCase))
                    {
                        string destinationPath = Path.Combine(extractPath, entry.FullName.Substring(folderName.Length + 1));

                        string directoryPath = Path.GetDirectoryName(destinationPath);
                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }

                        entry.ExtractToFile(destinationPath, true); // trueを指定して既存のファイルを上書き
                    }
                }
            }
        }


    }
}
