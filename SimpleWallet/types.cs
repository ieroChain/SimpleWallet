using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace SimpleWallet
{
    public class ReceivedDataEventArgs : EventArgs
    {
        public bool shouldDelete { get; set; }
        public int progress { get; set; }
        public bool isCancel { get; set; }
        public String fileName { get; set; }

        public ReceivedDataEventArgs(bool shouldDelete, int progress, bool isCancel, String fileName)
       {
           this.shouldDelete = shouldDelete;
           this.progress = progress;
           this.isCancel = isCancel;
           this.fileName = fileName;
       }
    }

    public delegate void ReceivedDataEventHandler(object sender,
                                                  ReceivedDataEventArgs e);

    public class DeamonErrorEventArgs : EventArgs
    {
        public String errMessage { get; set; }

        public DeamonErrorEventArgs(String errMessage)
        {
            this.errMessage = errMessage;
        }
    }

    public delegate void DeamonErrorEventHandler(object sender,
                                                  DeamonErrorEventArgs e);

    public class DaemonEventArgs : EventArgs
    {
        public bool Stop { get; set; }

        public DaemonEventArgs(bool Stop)
        {
            this.Stop = Stop;
        }
    }

    public delegate void DaemonEventHandler(object sender,
                                                  DaemonEventArgs e);
    public class Types
    {
        public static String version = "Zero Simple Wallet - Version 1.0.0";
        public static String startCommandsFile = Path.GetTempPath() + "\\commands.dat";
        public static String addressLabel = Path.GetTempPath() + "\\addressLabel.dat";
        public static String outputsSave = Path.GetTempPath() + "\\outputs.dat";
        public static String cfLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                 + "\\zero\\zero.conf";
        public Dictionary<bool, String> boolDict = new Dictionary<bool, String>();
        public Dictionary<int, String> intDict = new Dictionary<int, String>();
        public Dictionary<String, String> strDict = new Dictionary<String, String>();


        public enum GetAllDataType
        {
            ALL = 0,
            WITH_BALANCE,
            WITH_TRANSACTIONS,
            NONE,
            END
        }

        public enum TransactionType
        {
            SEND_COIN = 0,
            SHIELD_COIN,
            END
        }

        public enum StepSync
        {
            GET_BEST_HASH = 0,
            GET_BEST_TIME,
            END
        }

        public enum StepBalance
        {
            GET_CONFIRMED_BALANCE = 0,
            GET_UNCONFIRM_BALANCE,
            GET_BALANCE,
            GET_Z_ADDRESS,
            UPDATE_DATA,
            LIST_TRANSACTION,
            GET_CONNECTION_COUNT,
            END
        }

        public enum UpdateData
        {
            TIME = 0,
            HASH,
            END
        }

        public enum OutputType
        {
            DAEMOND = 0,
            SYNC,
            BALANCE,
            GET_TRANSACTION,
            OTHERS
        }

        public enum DownloadFileType
        {
            VERIFYING = 0,
            PROVING = 1
        }

        public enum DebugType
        {
            DEBUG = 0,
            PEERS = 1
        }

        public enum ConfigureResult
        {
            OK = 0,
            FAIL = 1,
            REINDEX = 2,
            DUPLICATE
        }

        public enum CtxMenuType
        {
            WALLET = 0,
            TRANSACTIONS,
            ADDRESS_BOOK
        }

        public class RightClickData
        {
            public bool isClicked { get; set; }
            public Types.CtxMenuType type { get; set; }
            public int rowIdx { get; set; }
            public int colIdx { get; set; }
            public int x { get; set; }
            public int y { get; set; }
        }

        public class ListAddressBook
        {
            public List<AddressBook> addressbook { get; set; }
        }

        public class ShieldData
        {
            public float remainingUTXOs { get; set; }
            public float remainingValue { get; set; }
            public float shieldingUTXOs { get; set; }
            public float shieldingValue { get; set; }
            public String opid { get; set; }
        }

        public class AllData
        {
            public String connectionCount { get; set; }
            public String besttime { get; set; } //remove
            public String time { get; set; }
            public String bestblockhash { get; set; }
            public String transparentbalance { get; set; }
            public String transparentbalanceunconfirmed { get; set; } 
            public String transparent { get; set; }
            public String privatebalance { get; set; }
            public String privatebalanceunconfirmed { get; set; }
            public String @private { get; set; }
            public String totalbalance { get; set; }
            public String totalbalanceunconfirmed { get; set; } 
            public String total { get; set; }
            public String unconfirmedbalance { get; set; }
            public List<Dictionary<String, String>> addressbalance { get; set; }
            public List<Transaction> listtransactions { get; set; }
        }

        public class BlockFormat
        {
            public String hash { get; set; }
            public String confirmations { get; set; }
            public String height { get; set; }
            public String version { get; set; }
            public String merkleroot { get; set; }
            public String time { get; set; }
            public String nonce { get; set; }
            public String solution { get; set; }
            public String bits { get; set; }
            public String difficulty { get; set; }
            public String chainwork { get; set; }
            public String previousblockhash { get; set; }
        }

        public class WalletFormat
        {
            public String address { get; set; }
            public String account { get; set; }
            public String amount { get; set; }
            public String confirmations { get; set; }
        }

        public class TransactionStatus
        {
            public String id { get; set; }
            public String status { get; set; }
        }

        public class Transaction
        {
            public String address { get; set; }
            public String category { get; set; }
            public String amount { get; set; }
            public String confirmations { get; set; }
            public String time { get; set; }
            public String txid { get; set; }
        }

        public class TransactionConverted
        {
            public String category { get; set; }
            public String confirmations { get; set; }
            public String amount { get; set; }
            public String time { get; set; }
            public String address { get; set; }
            public String txid { get; set; }

            public TransactionConverted(String category, String confirmations, String amount, String time, String address, String txid)
            {
                this.category = category;
                this.confirmations = confirmations;
                this.amount = amount;
                this.time = time;
                this.address = address;
                this.txid = txid;
            }
        }

        public class Unspent 
        {
            public String txid { get; set; }
            public String vout { get; set; }
            public String generated { get; set; }
            public String spendable { get; set; }
            public String address { get; set; }
            
        }

        public class AddressData
        {
            public String address { get; set; }
        }

        public class ValidAddress
        {
            public String address { get; set; }
            public String isvalid { get; set; }
        }

        public class AddressBook
        {
            public AddressBook(String label, String address)
            {
                this.address = address;
                this.label = label;
            }
            public String label { get; set; }
            public String address { get; set; }
        }

        public class BlockChainInfo
        {
            public String bestblockhash { get; set; }
        }

        public class PeerInfo
        {
            public String addr { get; set; }
        }

        public class Info
        {
            public String blocks { get; set; }
        }

        public class Outputs
        {
            public String txhash { get; set; }
            public int outputidx { get; set; }
        }

        public class OutputsList
        {
            public List<Outputs> outputslist { get; set; }
        }

    }
}
