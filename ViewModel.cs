using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Linq;
using System.ComponentModel;
using System.Windows;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text;

namespace Test
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            KeySize = 2048 * 2 * 2;

            GenerateNewKeyButtonText = $"Generate New {keySize} Bit Key";
            PublicKeySaved = false;

            var numberOfExistingKeys = 0;
            NextCryptoKeyName = $"Bogus-{numberOfExistingKeys + 1}";
            ImportedKeyName = $"Bogus-{numberOfExistingKeys}";
            SavePublicKeyToDatabaseButtonText = $"Save Public Key to Database\nAs {NextCryptoKeyName}";
            SavePrivateKeyButtonText = $"Save Private Key to Local Machine\nAs {NextCryptoKeyName}";
        }

        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                if (isBusy != value)
                {
                    isBusy = value;
                    RaisePropertyChanged(nameof(IsBusy));
                    RaisePropertyChanged(nameof(IsBusyVisibility));
                }
            }
        }

        public Visibility IsBusyVisibility
        {
            get { return IsBusy ? Visibility.Visible : Visibility.Hidden; }
        }

        public event EventHandler<EventArgs> SendUiMessage;

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private AsyncCommand generateNewKey;
        public AsyncCommand GenerateNewKey => generateNewKey ?? (generateNewKey = new AsyncCommand(generateNewKey_ExecuteAsync, () => !IsBusy));

        private async Task generateNewKey_ExecuteAsync()
        {

        }

        private string generateNewKeyButtonText;
        public string GenerateNewKeyButtonText
        {
            get { return generateNewKeyButtonText; }
            set
            {
                if (generateNewKeyButtonText != value)
                {
                    generateNewKeyButtonText = value;
                    RaisePropertyChanged(nameof(GenerateNewKeyButtonText));
                }
            }
        }

        private string privateKeyCleartext;
        public string PrivateKeyCleartext
        {
            get { return privateKeyCleartext; }
            set
            {
                if (privateKeyCleartext != value)
                {
                    privateKeyCleartext = value;
                    RaisePropertyChanged(nameof(PrivateKeyCleartext));
                }
            }
        }

        private string publicKeyCleartext;
        public string PublicKeyCleartext
        {
            get { return publicKeyCleartext; }
            set
            {
                if (publicKeyCleartext != value)
                {
                    publicKeyCleartext = value;
                    RaisePropertyChanged(nameof(PublicKeyCleartext));
                }
            }
        }

        private string nextCryptoKeyName;
        public string NextCryptoKeyName
        {
            get { return nextCryptoKeyName; }
            set
            {
                if (nextCryptoKeyName != value)
                {
                    nextCryptoKeyName = value;
                    RaisePropertyChanged(nameof(NextCryptoKeyName));
                }
            }
        }

        private string savePublicKeyToDatabaseButtonText;
        public string SavePublicKeyToDatabaseButtonText
        {
            get { return savePublicKeyToDatabaseButtonText; }
            set
            {
                if (savePublicKeyToDatabaseButtonText != value)
                {
                    savePublicKeyToDatabaseButtonText = value;
                    RaisePropertyChanged(nameof(SavePublicKeyToDatabaseButtonText));
                }
            }
        }

        private string savePrivateKeyButtonText;
        public string SavePrivateKeyButtonText
        {
            get { return savePrivateKeyButtonText; }
            set
            {
                if (savePrivateKeyButtonText != value)
                {
                    savePrivateKeyButtonText = value;
                    RaisePropertyChanged(nameof(SavePrivateKeyButtonText));
                }
            }
        }

        private bool publicKeySaved;
        public bool PublicKeySaved
        {
            get { return publicKeySaved; }
            set
            {
                if (publicKeySaved != value)
                {
                    publicKeySaved = value;
                    RaisePropertyChanged(nameof(PublicKeySaved));
                }
            }
        }

        private bool privateKeySaved;
        public bool PrivateKeySaved
        {
            get { return privateKeySaved; }
            set
            {
                if (privateKeySaved != value)
                {
                    privateKeySaved = value;
                    RaisePropertyChanged(nameof(PrivateKeySaved));
                }
            }
        }

        private bool privateKeyInPasswordSafe;
        public bool PrivateKeyInPasswordSafe
        {
            get { return privateKeyInPasswordSafe; }
            set
            {
                if (privateKeyInPasswordSafe != value)
                {
                    privateKeyInPasswordSafe = value;
                    RaisePropertyChanged(nameof(PrivateKeyInPasswordSafe));
                }
            }
        }

        private int keySize;
        public int KeySize
        {
            get { return keySize; }
            set
            {
                if (keySize != value)
                {
                    keySize = value;
                    RaisePropertyChanged(nameof(KeySize));
                }
            }
        }

        private string importedPrivateKey;
        public string ImportedPrivateKey
        {
            get { return importedPrivateKey; }
            set
            {
                if (importedPrivateKey != value)
                {
                    importedPrivateKey = value;
                    RaisePropertyChanged(nameof(ImportedPrivateKey));
                }
            }
        }

        private string importedKeyName;
        public string ImportedKeyName
        {
            get { return importedKeyName; }
            set
            {
                if (importedKeyName != value)
                {
                    importedKeyName = value;
                    RaisePropertyChanged(nameof(ImportedKeyName));
                }
            }
        }

        private RelayCommand importPrivateKey;
        public RelayCommand ImportPrivateKey => importPrivateKey ?? (importPrivateKey = new RelayCommand(
            () =>
            {
                try
                {
                    var overwriteExisting = true;
                    if (!overwriteExisting)
                        return;
                    var privateBytes = System.Convert.FromBase64String(ImportedPrivateKey);
                }
                catch (Exception ex)
                {
                }
            },
            () => !String.IsNullOrWhiteSpace(ImportedPrivateKey)
                && !IsBusy
                && !String.IsNullOrWhiteSpace(ImportedKeyName)));
    }
}