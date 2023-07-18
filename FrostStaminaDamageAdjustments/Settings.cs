using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.WPF.Reflection.Attributes;

namespace FrostStaminaDamageAdjustments
{
    public class Settings
    {
        [MaintainOrder]
        
        [SettingName("Ignored mods")]
        [Tooltip("A list of mods that should not be patched. Each entry is a string matching a plugin name.")]
        public List<string> Ignored
        {
            get => _ignored;
            set => _ignored = value;
        }

        private List<string> _ignored = new();
        private HashSet<ModKey>? _ignoredMods;
        public HashSet<ModKey> IgnoredMods
        {
            get
            {
                var modKeys = new List<ModKey>();
                IList<ModKey> modFiles = Program.State.LoadOrder.Keys.ToList();
                foreach (var modFilter in Ignored.Where(modFilter => modFilter != ""))
                    modKeys.AddRange(modFiles.Where(modKey => modKey.FileName.String.Contains(modFilter, StringComparison.OrdinalIgnoreCase)));
                _ignoredMods = new HashSet<ModKey>(modKeys);
                return _ignoredMods;
            }
        }

        private List<string[]> _blacklist = new();

        [SettingName("Blacklisted EditorIDs")]
        [Tooltip("Each entry is a comma separated list of partial Magic Effect EditorIDs, case insensitive.")]
        public List<string> Blacklist
        {
            get => _blacklist.Select(filter => string.Join(",", filter)).ToList();
            set => _blacklist = ParseIdFilters(value);
        }

        [SettingName("Stamina Damage Multiplier")]
        [Tooltip("The multiplier that will be applied to all stamina damage dealt by frost spell effects. " +
                 "Positive numbers above 1.0 will increase the stamina damage whereas a value of 0 will negate it entirely.")]
        public double DamageMultiplier { get; set; } = 0.5;

        private static List<string[]> ParseIdFilters(IEnumerable<string> filterData)
        {
            List<string[]> result = new();
            foreach (var filterDataItem in filterData)
            {
                if (string.IsNullOrEmpty(filterDataItem))
                    continue;

                var filterElements = filterDataItem.Split(',');
                if (filterElements.Length > 0)
                    result.Add(filterElements);
            }

            return result;
        }
    }
}
