using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Tasks;

namespace Tasks
{
    public static class CsvTasks
    {
        private const string Header = "Id,Title,AssignmentType,Due,Status,CreatedAt,CompletedAt,MinutesSpent";

        public static List<TaskItem> Load(string path)
        {
            var tasks = new List<TaskItem>();
            if (!File.Exists(path))
                return tasks;

            var lines = File.ReadAllLines(path);
            foreach (var line in lines.Skip(1)) // skip header
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                // Very simple CSV parsing (no quoted commas). Keep titles comma-free or improve later.
                var parts = line.Split(',');
                if (parts.Length < 8) continue;

                var t = new TaskItem
                {
                    Id = parts[0],
                    Title = parts[1],
                    AssignmentType = parts[2],
                    Due = ParseDate(parts[3]),
                    Status = parts[4],
                    CreatedAt = ParseDate(parts[5]),
                    CompletedAt = string.IsNullOrWhiteSpace(parts[6]) ? null : ParseDate(parts[6]),
                    MinutesSpent = int.TryParse(parts[7], out int m) ? m : (int?)null
                };

                tasks.Add(t);
            }
            return tasks;
        }

        public static void Save(string path, List<TaskItem> tasks)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path)!);

            using var sw = new StreamWriter(path, false);
            sw.WriteLine(Header);

            foreach (var t in tasks.OrderBy(x => x.Status).ThenBy(x => x.Due))
            {
                sw.WriteLine(string.Join(",",
                    Safe(t.Id),
                    Safe(t.Title),
                    Safe(t.AssignmentType),
                    t.Due.ToString("o", CultureInfo.InvariantCulture),
                    Safe(t.Status),
                    t.CreatedAt.ToString("o", CultureInfo.InvariantCulture),
                    t.CompletedAt.HasValue ? t.CompletedAt.Value.ToString("o", CultureInfo.InvariantCulture) : "",
                    t.MinutesSpent.HasValue ? t.MinutesSpent.Value.ToString(CultureInfo.InvariantCulture) : ""
                ));

            }
        }

        public static void Add(string path, TaskItem task)
        {
            var tasks = Load(path);
            tasks.Add(task);
            Save(path, tasks);
        }

        public static void Complete(string path, string taskId, int minutesSpent)
        {
            var tasks = Load(path);
            var t = tasks.FirstOrDefault(x => x.Id == taskId);
            if (t == null) return;

            t.Status = "Completed";
            t.CompletedAt = DateTime.Now;
            t.MinutesSpent = minutesSpent;

            Save(path, tasks);
        }

        public static void Delete(string path, string taskId)
        {
            var tasks = Load(path);
            tasks = tasks.Where(t => t.Id != taskId).ToList();
            Save(path, tasks);
        }

        private static DateTime ParseDate(string iso)
            => DateTime.Parse(iso, null, DateTimeStyles.RoundtripKind);

        private static string Safe(string s)
            => (s ?? "").Replace(",", " "); // basic protection
    }
}
