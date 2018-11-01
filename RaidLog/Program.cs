using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace RaidLog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Directory.CreateDirectory("data");

            List<string> lines = File.ReadAllLines("Index.html").ToList();

            lines.Insert(18, AddNewRaidDay());

            File.WriteAllLines("Index.html", lines);
        }

        private static string AddNewRaidDay()
        {
            string date = DateTime.Now.ToShortDateString().Replace(".", string.Empty);
            string data = $"<a href='#item-{date}' class='list-group-item' data-toggle='collapse'><i class='glyphicon glyphicon-chevron-right'></i>{DateTime.Now.ToShortDateString()}</a>"
                + $"<div class='list-group collapse' id='item-{date}'>";

            data += CreateWing1(date);
            data += CreateWing2(date);
            data += CreateWing3(date);
            data += CreateWing4(date);
            data += CreateWing5(date);

            data += "</div>";
            return data;
        }

        private static string CreateWing1(string date)
        {
            string wing1 = $"<a href='#item-{date}-wing1' class='list-group-item' data-toggle='collapse'><i class='glyphicon glyphicon-chevron-right'></i>Wing 1 - Spirit Vale</a>"
                + $"<div class='list-group collapse' id='item-{date}-wing1'>";
            string vale = AddData("15438");
            string gorse = AddData("15429");
            string sab = AddData("15375");
            wing1 += string.IsNullOrWhiteSpace(vale) ? "" : $"<a href='{vale}' target='_blank' class='list-group-item'>Vale Guardian</a>";
            wing1 += string.IsNullOrWhiteSpace(gorse) ? "" : $"<a href='{gorse}' target='_blank' class='list-group-item'>Gorseval</a>";
            wing1 += string.IsNullOrWhiteSpace(sab) ? "" : $"<a href='{sab}' target='_blank' class='list-group-item'>Sabetha</a>";
            wing1 += "</div>";

            if (string.IsNullOrWhiteSpace(vale)
                && string.IsNullOrWhiteSpace(gorse)
                && string.IsNullOrWhiteSpace(sab))
            {
                return "";
            }
            return wing1;
        }

        private static string CreateWing2(string date)
        {
            string wing2 = $"<a href='#item-{date}-wing2' class='list-group-item' data-toggle='collapse'><i class='glyphicon glyphicon-chevron-right'></i>Wing 2 - Salvation Pass</a>"
                + $"<div class='list-group collapse' id='item-{date}-wing2'>";
            string slothasor = AddData("16123");
            string matthias = AddData("16115");
            wing2 += string.IsNullOrWhiteSpace(slothasor) ? "" : $"<a href='{slothasor}' target='_blank' class='list-group-item'>Slothasor</a>";
            wing2 += string.IsNullOrWhiteSpace(matthias) ? "" : $"<a href='{matthias}' target='_blank' class='list-group-item'>Matthias</a>";
            wing2 += "</div>";
            if (string.IsNullOrWhiteSpace(slothasor) && string.IsNullOrWhiteSpace(matthias))
            {
                return "";
            }
            return wing2;
        }

        private static string CreateWing3(string date)
        {
            string wing3 = $"<a href='#item-{date}-wing3' class='list-group-item' data-toggle='collapse'><i class='glyphicon glyphicon-chevron-right'></i>Wing 3 - Stronghold of the Faithful</a>"
                + $"<div class='list-group collapse' id='item-{date}-wing3'>";
            string kfc = AddData("16235");
            string xera = AddData("16246");
            wing3 += string.IsNullOrWhiteSpace(kfc) ? "" : $"<a href='{kfc}' target='_blank' class='list-group-item'>Keep Construct</a>";
            wing3 += string.IsNullOrWhiteSpace(xera) ? "" : $"<a href='{xera}' target='_blank' class='list-group-item'>Xera</a>";
            wing3 += "</div>";
            if (string.IsNullOrWhiteSpace(kfc) && string.IsNullOrWhiteSpace(xera))
            {
                return "";
            }
            return wing3;
        }

        private static string CreateWing4(string date)
        {
            string wing4 = $"<a href='#item-{date}-wing4' class='list-group-item' data-toggle='collapse'><i class='glyphicon glyphicon-chevron-right'></i>Wing 4 - Bastion of the Penitent</a>"
                + $"<div class='list-group collapse' id='item-{date}-wing4'>";
            string cairn = AddData("17194");
            string mursaat = AddData("17172");
            string samarog = AddData("17188");
            string deimos = AddData("17154");
            wing4 += string.IsNullOrWhiteSpace(cairn) ? "" : $"<a href='{cairn}' target='_blank' class='list-group-item'>Cairn the Indomitable</a>";
            wing4 += string.IsNullOrWhiteSpace(mursaat) ? "" : $"<a href='{mursaat}' target='_blank' class='list-group-item'>Mursaat Overseer</a>";
            wing4 += string.IsNullOrWhiteSpace(samarog) ? "" : $"<a href='{samarog}' target='_blank' class='list-group-item'>Samarog</a>";
            wing4 += string.IsNullOrWhiteSpace(deimos) ? "" : $"<a href='{deimos}' target='_blank' class='list-group-item'>Deimos</a>";
            wing4 += "</div>";

            if (string.IsNullOrWhiteSpace(cairn)
                && string.IsNullOrWhiteSpace(mursaat)
                && string.IsNullOrWhiteSpace(samarog)
                && string.IsNullOrWhiteSpace(deimos))
            {
                return "";
            }
            return wing4;
        }


        private static string CreateWing5(string date)
        {
            string wing5 = $"<a href='#item-{date}-wing5' class='list-group-item' data-toggle='collapse'><i class='glyphicon glyphicon-chevron-right'></i>Wing 5 - Hall of Chains</a>"
              + $"<div class='list-group collapse' id='item-{date}-wing5'>";
            string horror = AddData("19767");
            string dhuum = AddData("19450");
            wing5 += string.IsNullOrWhiteSpace(horror) ? "" : $"<a href='{horror}' target='_blank' class='list-group-item'>Soulless Horror</a>";
            wing5 += string.IsNullOrWhiteSpace(dhuum) ? "" : $"<a href='{dhuum}' target='_blank' class='list-group-item'>Dhuum</a>";
            wing5 += "</div>";

            if (string.IsNullOrWhiteSpace(horror)
                && string.IsNullOrWhiteSpace(dhuum))
            {
                return "";
            }
            return wing5;
        }

        private static string AddData(string bossId)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $@"Guild Wars 2\addons\arcdps\arcdps.cbtlogs\{bossId}");

            if (!Directory.Exists(path))
            {
                return "";
            }

            var file = Directory.GetFiles(path);
            if (file.Count() == 1)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "raid_heroes.exe";
                startInfo.Arguments = $"\"{file.FirstOrDefault()}\"";
                var process = Process.Start(startInfo);
                process.WaitForExit();
            }

            var newFile = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory);

            foreach (var item in newFile)
            {
                if (item.EndsWith("html") && !item.ToLower().Contains("index"))
                {
                    File.Move(item, $@"data\{Path.GetFileName(item)}");
                    File.Delete(item);
                    return $@"data\{Path.GetFileName(item)}";
                }
            }

            return "";
        }
    }
}
