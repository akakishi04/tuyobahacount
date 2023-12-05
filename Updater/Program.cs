using System.Diagnostics;
using System.IO.Compression;

namespace Updater
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] splitargs = args[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
             

                string zipPath = args[0];
                string extractPath = splitargs[0];
                string appPath = splitargs[1];
                int processId = int.Parse(splitargs[2]);
                extractPath = extractPath.Replace("\"", "");
                Log($"アップデート開始: {zipPath}, {extractPath}, {appPath}, PID: {processId}");

                // メインアプリケーションのプロセスが終了するのを待つ
                

                Log("メインアプリケーションのプロセスが終了しました。");

                // ZIPファイルを解凍
              ExtractFolderFromZip(zipPath, extractPath, "TuyobahaCount");
                Log("ZIPファイルを解凍しました。");

                File.Delete(zipPath);

                // メインアプリケーションを再起動
                Process.Start(appPath);
                Log("メインアプリケーションを再起動しました。");
            }
            catch (Exception ex)
            {
                Log($"エラーが発生しました: {ex.Message}");
            }

            Console.WriteLine("アップデートが完了しました。続行するには何かキーを押してください...");
            Console.ReadLine();
        }

        static void Log(string message)
        {
            string logFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "updater.log");
            File.AppendAllText(logFile, $"{DateTime.Now}: {message}\n");
        }


        public static void ExtractFolderFromZip(string zipPath, string extractPath, string folderName)
        {
            using (ZipArchive archive = ZipFile.OpenRead(zipPath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    // フォルダ内のファイルのみをチェック
                    if (entry.FullName.StartsWith(folderName + "/", StringComparison.OrdinalIgnoreCase))
                    {
                        string destinationPath = Path.Combine(extractPath, entry.FullName.Substring(folderName.Length + 1));

                        // ディレクトリが存在しない場合は作成
                        string directoryPath = Path.GetDirectoryName(destinationPath);
                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }

                        // ファイルを展開
                        entry.ExtractToFile(destinationPath, true);
                    }
                }
            }
        }
    }
}