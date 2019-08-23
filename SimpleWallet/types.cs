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
        public static String version = "Zero Simple Wallet - Version 2.0.2";

        public static String startCommandsFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                        "\\zero\\simplewallet\\commands.dat";
        public static String addressLabel = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                        "\\zero\\simplewallet\\addressLabel.dat";
        public static String outputsSave = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                        "\\zero\\simplewallet\\outputs.dat";
        public static String mnLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                        "\\zero\\zeronode.conf";
        public static String cfLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                        "\\zero\\zero.conf";
        public Dictionary<bool, String> boolDict = new Dictionary<bool, String>();
        public Dictionary<int, String> intDict = new Dictionary<int, String>();
        public Dictionary<String, String> strDict = new Dictionary<String, String>();

        public enum MasternodeType
        {
            NONE = 0,
            ON,
            OFF
        }

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
            IMPORT_KEY,
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
            MASTERNODE,
            GET_TRANSACTION,
            OTHERS
        }

        public enum DownloadFileType
        {
            VERIFYING = 0,
            PROVING = 1,
            GROTH = 2,
            SPEND = 3,
            OUTPUT = 4
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
            ADDRESS_BOOK,
            MASTERNODE,
            MASTERNODE_GLOBAL
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
            public String besttime { get; set; }
            public String bestblockhash { get; set; }
            public String transparentbalance { get; set; }
            public String transparentbalanceunconfirmed { get; set; }
            public String privatebalance { get; set; }
            public String privatebalanceunconfirmed { get; set; }
            public String totalbalance { get; set; }
            public String totalunconfirmed { get; set; }
            public String lockedbalance { get; set; }
            public String immaturebalance { get; set; }
            public List<Dictionary<String, AllDataAddress>> addressbalance { get; set; }
            public List<ZeroTransaction> listtransactions { get; set; }
        }

        public class AllDataAddress
        {
            public String amount { get; set; }
            public String unconfirmed { get; set; }
            public String locked { get; set; }
            public String immature { get; set; }
            public String ismine { get; set; }
        }

        public class ZeroTransaction
        {
            public String txid { get; set; }
            public String coinbase { get; set; }
            public String category { get; set; }
            public String blockhash { get; set; }
            public String blockindex { get; set; }
            public String blocktime { get; set; }
            public String expiryheight { get; set; }
            public String confirmations { get; set; }
            public String time { get; set; }
            public String size { get; set; }
            public List<String> conflicts { get; set; }
            public spendList spends { get; set; }
            public receivedList received { get; set; }
            public sendList sends { get; set; }
        }

        public class spendList
        {
             public List<transparentSpendList> transparentSpends { get; set; }
             public List<saplingSpendList> saplingSpends { get; set; }
             public List<sproutSpendList> sproutSpends { get; set; }
             public String totalSpends { get; set; }
             public Boolean missingSpendingKeys { get; set; }
        }

        public class transparentSpendList
        {
            public String address { get; set; }
            public String scriptPubKey { get; set; }
            public String amount { get; set; }
            public String vout { get; set; }

        }

        public class saplingSpendList
        {
            public String address { get; set; }
            public String amount { get; set; }

        }

        public class sproutSpendList
        {
            public String address { get; set; }
            public String amount { get; set; }

        }

        public class receivedList
        {
            public List<transparentReceivedList> transparentReceived { get; set; }
            public List<saplingReceivedList> saplingReceived { get; set; }
            public List<sproutReceivedList> sproutReceived { get; set; }
            public String totalReceived { get; set; }
        }

        public class transparentReceivedList
        {
            public String address { get; set; }
            public String amount { get; set; }

        }

        public class saplingReceivedList
        {
            public String address { get; set; }
            public String amount { get; set; }

        }

        public class sproutReceivedList
        {
            public String address { get; set; }
            public String amount { get; set; }

        }

        public class sendList
        {
            public List<transparentSendList> transparentSends { get; set; }
            public List<saplingSendList> saplingSends { get; set; }
            public List<sproutSendList> sproutSends { get; set; }
            public String totalSends { get; set; }
            public String missingSaplingOVK { get; set; }
        }

        public class transparentSendList
        {
            public String address { get; set; }
            public String amount { get; set; }

        }

        public class saplingSendList
        {
            public String address { get; set; }
            public String amount { get; set; }

        }

        public class sproutSendList
        {
            public String vpub_old { get; set; }
            public String vpub_new { get; set; }

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

            public Transaction()
            {

            }

            public Transaction(String category, String confirmations, String amount, String time, String address, String txid)
            {
                this.category = category;
                this.confirmations = confirmations;
                this.amount = amount;
                this.time = time;
                this.address = address;
                this.txid = txid;
            }
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
            public List<valuePool> valuePools { get; set; }
            public String blocks { get; set; }
        }

        public class valuePool
        {
            public String id { get; set; }
            public String monitored { get; set; }
            public String chainValue { get; set; }
            public String chainValueZat { get; set; }
        }


        public class PeerInfo
        {
            public String addr { get; set; }
        }

        public class Info
        {
            public String version { get; set; }
            public String protocolversion { get; set; }
            public String walletversion { get; set; }
            public String blocks { get; set; }
            public String connections { get; set; }
            public String difficulty { get; set; }
            public String testnet { get; set; }
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

        public class ZeroNodeCount
        {
            public String total { get; set; }
            public String stable { get; set; }
            public String enabled { get; set; }
            public String inqueue { get; set; }
            public String ipv4 { get; set; }
            public String ipv6 { get; set; }
            public String onion { get; set; }
        }

        public class Masternode
        {
            public Masternode(string status, string alias, string ipAddress, string privKey, string txHash, string txindex)
            {
                this.status = status;
                this.alias = alias;
                this.ipAddress = ipAddress;
                this.privKey = privKey;
                this.txHash = txHash;
                this.index = txindex;
            }
            public Masternode()
            {
                this.status = this.alias = this.ipAddress = this.privKey = this.txHash = this.index = "";
            }

            public Masternode(Masternode temp)
            {
                this.status = temp.status;
                this.alias = temp.alias;
                this.ipAddress = temp.ipAddress;
                this.privKey = temp.privKey;
                this.txHash = temp.txHash;
                this.index = temp.index;
            }

            public Masternode(List<String> temp)
            {
                this.status = temp[0];
                this.alias = temp[1];
                this.ipAddress = temp[2];
                this.privKey = temp[3];
                this.txHash = temp[4];
                this.index = temp[5];
            }

            public String MNToString()
            {
                return (status == "ENABLE" ? "" : "#") + alias + " " + ipAddress + " " + privKey + " " + txHash + " " + index;
            }

            public String status { get; set; }
            public String alias { get; set; }
            public String ipAddress { get; set; }
            public String privKey { get; set; }
            public String txHash { get; set; }
            public String index { get; set; }
        }
        public class MasternodeList
        {
            public List<MasternodeDetail> zeronodelist { get; set; }
        }

        public class MasternodeDetail
        {
            public MasternodeDetail(MasternodeDetail temp)
            {
                if (temp != null)
                {
                    this.rank = temp.rank;
                    this.addr = temp.addr;
                    this.version = temp.version;
                    this.status = temp.status;
                    this.activetime = temp.activetime;
                    this.lastseen = temp.lastseen;
                    this.lastpaid = temp.lastpaid;
                    this.txhash = temp.txhash;
                    this.network = temp.network;
                    this.outidx = temp.outidx;
                    this.ip = temp.ip;
                }
            }
            public int rank { get; set; }
            public String addr { get; set; }
            public int version { get; set; }
            public String status { get; set; }
            public int activetime { get; set; }
            public int lastseen { get; set; }
            public int lastpaid { get; set; }
            public String txhash { get; set; }
            public String network { get; set; }
            public int outidx { get; set; }
            public String ip { get; set; }
        }

        public class MasternodeDetailConverted
        {
            public String rank { get; set; }
            public String addr { get; set; }
            public String version { get; set; }
            public String status { get; set; }
            public String activetime { get; set; }
            public String lastseen { get; set; }
            public String lastpaid { get; set; }
            public String txhash { get; set; }
            public String ip { get; set; }

            public MasternodeDetailConverted(String rank, String addr, String version,
                String status, String activetime, String lastseen, String lastpaid, String txhash, String ip)
            {
                this.rank = rank;
                this.addr = addr;
                this.version = version;
                this.status = status;
                this.activetime = activetime;
                this.lastseen = lastseen;
                this.lastpaid = lastpaid;
                this.txhash = txhash;
                this.ip = ip;
            }
        }

        public class StartMNResponse
        {
            public String overall { get; set; }
            public List<Detail> detail { get; set; }
        }

        public class Detail
        {
            public String alias { get; set; }
            public String result { get; set; }
            public String error { get; set; }
        }
    }
}
