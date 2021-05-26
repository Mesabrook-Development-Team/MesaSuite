using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace ReleaseUtility.Steps
{
    public class ValidationResult
    {
        public List<string> Errors { get; set; } = new List<string>();
        private Dictionary<byte[], string> _warnings = new Dictionary<byte[], string>();
        public IReadOnlyDictionary<byte[], string> Warnings => _warnings;

        public bool IsValid(HashSet<byte[]> warningHashes = null)
        {
            warningHashes = warningHashes ?? new HashSet<byte[]>();
            return !Errors.Any() && !Warnings.Any(kvp => !warningHashes.Any(existingHash => kvp.Key.SequenceEqual(existingHash)));
        }

        public void AddWarning(string warning)
        {
            byte[] hash;
            using (Stream stream = new MemoryStream())
            using (StreamWriter writer = new StreamWriter(stream))
            using (MD5 mD5 = MD5.Create())
            {
                writer.Write(warning);
                hash = mD5.ComputeHash(stream);
            }

            _warnings.Add(hash, warning);
        }
    }
}
