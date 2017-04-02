using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrakenClient;
using System.Collections;
using System.Globalization;
using System.Threading;
using Jayrock.Json;
using Jayrock.Json.Conversion;
using System.Diagnostics;
using System.IO;
using System.Timers;



namespace KrakenClientConsole
{
    public class Program
    {

        public static KrakenClient.KrakenClient client = new KrakenClient.KrakenClient();

        public static Broker broker = new Broker();

        
        
        public static void Main(string[] args)
        {

            //FileStream filestream = new FileStream("outprivate.txt", FileMode.Create);
            //var streamwriter = new StreamWriter(filestream);
            //streamwriter.AutoFlush = true;
            //Console.SetOut(streamwriter);
            //Console.SetError(streamwriter);
            Console.WriteLine("calling kraken api...\n\n");
            GetSimpleinfogeneral();
           //GetSimpleinfoprivate();
            
            //Decision("XXBTZEUR");
            //Tryrepeat();

            #region Simple trading requests

            //var closeDictionary = new Dictionary<string,string>();
            //closeDictionary.Add("ordertype","stop-loss-profit");
            //closeDictionary.Add("price","#5%");
            //closeDictionary.Add("price2","#10");

            //var addOrderRes = client.AddOrder("XXBTZEUR",
            //    "buy",
            //    "limit",
            //    (decimal)2.12345678,
            //    (decimal)101.9901,
            //    null,
            //    @"1:1",
            //    "",
            //    "",
            //    "",
            //    "",
            //    "",
            //    true,                
            //    closeDictionary);

            //Console.WriteLine("add order result: " + addOrderRes.ToString());

            //var cancelOrder = client.CancelOrder("");
            //Console.WriteLine("cancel order : " + cancelOrder.ToString());

            #endregion

            #region Using the broker helper

            //KrakenOrder openingOrder = broker.CreateOpeningOrder2(OrderType.buy, KrakenOrderType.stop_loss, 420.1M, 10,415M,viqc:true,validateOnly: false);

            //PlaceOrder(ref openingOrder, true);

            //CancelOrder(ref openingOrder);

            Stopwatch stopwatch = new Stopwatch();
            KrakenOrder order = new KrakenOrder();
            order.TxId = "OYNRKT-RQB5J-OM4DQU";
            for (int i = 1; i <= 10; i++)
            {

                stopwatch.Start();
                var res = broker.RefreshOrder(ref order);
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed.ToString());
                stopwatch.Start();
            }
            #endregion    

            //streamwriter.AutoFlush = false;

            Console.WriteLine("stop");
            Console.ReadKey();
        }


        #region Simple requests

        static void GetSimpleinfoprivate()
        {
            #region privatedata

            var openOrders = client.GetOpenOrders();
            Console.WriteLine("open orders: " + openOrders.ToString() + "\n\n");

            var closedOrders = client.GetClosedOrders();
            Console.WriteLine("closed orders: " + closedOrders.ToString() + "\n\n");

            var queryOrders = client.QueryOrders(string.Empty);
            Console.WriteLine("query orders: " + queryOrders.ToString() + "\n\n");

            var tradesHistory = client.GetTradesHistory(string.Empty);
            Console.WriteLine("trades history: " + tradesHistory.ToString() + "\n\n");

            var queryTrades = client.QueryTrades();
            Console.WriteLine("query trades: " + queryTrades.ToString() + "\n\n");

            var openPositions = client.GetOpenPositions();
            Console.WriteLine("open positions: " + openPositions.ToString() + "\n\n");

            var ledgers = client.GetLedgers();
            Console.WriteLine("ledgers: " + ledgers.ToString() + "\n\n");

            var queryLedgers = client.QueryLedgers();
            Console.WriteLine("query ledgers: " + queryLedgers.ToString() + "\n\n");
            #endregion
        }
        static void GetSimpleinfogeneral()
        {

            #region Datageneral

            var time = client.GetServerTime();
            Console.WriteLine("time: " + time.ToString() + "\n\n");

            //Console.ReadKey();

            var assets = client.GetActiveAssets();
            Console.WriteLine("assets: " + assets.ToString() + "\n\n");

            //Console.ReadKey();

            var assetPairs = client.GetAssetPairs(new List<string> { "XXBTZEUR" });
            Console.WriteLine("asset pairs: " + assetPairs.ToString() + "\n\n");
            Console.WriteLine(SplitJSON(assetPairs.ToString(), "fees"));
            //Console.ReadKey();

            var ticker = client.GetTicker(new List<string> { "XXBTZEUR" });
            Console.WriteLine("ticker: " + ticker.ToString() + "\n\n");

            //Console.ReadKey();

            var depth = client.GetOrderBook("XXBTZUSD", 1);
            Console.WriteLine("depth: " + depth.ToString() + "\n\n");

            //Console.ReadKey();

            var ohlc = client.GetOHLCData("XXBTZEUR", 137589964200000000);
            Console.WriteLine("ohlc: " + ohlc.ToString() + "\n\n");

            var trades = client.GetRecentTrades("XXBTZEUR", 137589964200000000);
            Console.WriteLine("trades: " + trades.ToString() + "\n\n");

            //Console.ReadKey();

            var spreads = client.GetRecentSpreadData("XXBTZEUR", 137589964200000000);
            Console.WriteLine("spreads: " + spreads.ToString() + "\n\n");

            //Console.ReadKey();

            var balance = client.GetBalance();
            Console.WriteLine("balance: " + balance.ToString() + "\n\n");
            Console.WriteLine(SplitJSON(balance.ToString(), "ZEUR"));

            //Console.ReadKey();

            var tradeBalance = client.GetTradeBalance("currency", string.Empty);
            Console.WriteLine("trade balance: " + tradeBalance.ToString() + "\n\n");

            //Console.ReadKey();

            var tradeVolume = client.GetTradeVolume("XXBTZEUR");
            Console.WriteLine("trade volume: " + tradeVolume.ToString() + "\n\n");

            #endregion

        }

        #endregion

        #region principal
        static void Decision(string pairname)
        {
            //double ask;
            //double bid;
            //double lasttradeclosed;
            //double volumetoday;
            //double volume24;
            //double vwaptoday;
            //double vwap24;
            //double lowtoday;
            //double hightoday;
            //double low24;
            //double high24;
            //double openingprice;
            string result;

            var ticker = client.GetTicker(new List<string> { pairname  });
            //Console.WriteLine(SplitJSON(ticker.ToString(), "a"));
            //Console.WriteLine("ticker: " + ticker.ToString() + "\n\n");
            //ask = Convert.ToDouble(SplitJSON(ticker.ToString(), "a"));
            //bid=Convert.ToDouble(SplitJSON(ticker.ToString(), "b"));
            //lasttradeclosed=Convert.ToDouble(SplitJSON(ticker.ToString(), "c"));
            //volumetoday=Convert.ToDouble(SplitJSON(ticker.ToString(), "v"));
            //vwaptoday = Convert.ToDouble(SplitJSON(ticker.ToString(), "p"));
            //lowtoday = Convert.ToDouble(SplitJSON(ticker.ToString(), "l"));
            //hightoday = Convert.ToDouble(SplitJSON(ticker.ToString(), "h"));
            //volume24 = Convert.ToDouble(SplitJSON(ticker.ToString(), "v", 2));
            //vwap24 = Convert.ToDouble(SplitJSON(ticker.ToString(), "p", 2));
            //low24 = Convert.ToDouble(SplitJSON(ticker.ToString(), "l", 2));
            //high24 = Convert.ToDouble(SplitJSON(ticker.ToString(), "h", 2));
            //openingprice = Convert.ToDouble(SplitJSON(ticker.ToString(), "o"));
            //result = ask + ";" + bid + ";" + lasttradeclosed + ";" + volumetoday + ";" + vwaptoday + ";" + lowtoday + ";" + hightoday + ";" + volume24 + ";" + vwap24 + ";" + low24 + ";" + high24 + ";" + openingprice;
            result = SplitJSON(ticker.ToString(), "a") + ";" + SplitJSON(ticker.ToString(), "b") + ";" + SplitJSON(ticker.ToString(), "c") + ";" + SplitJSON(ticker.ToString(), "v") + ";" + SplitJSON(ticker.ToString(), "p") + ";" + SplitJSON(ticker.ToString(), "l") + ";" + SplitJSON(ticker.ToString(), "h") + ";"+SplitJSON(ticker.ToString(), "v",2) + ";" +SplitJSON(ticker.ToString(), "p",2) + ";" +SplitJSON(ticker.ToString(), "l",2) + ";" +SplitJSON(ticker.ToString(), "o") ;
            Console.WriteLine(result);

        }

        static void Tryrepeat()
        {
            FileStream filestream = new FileStream("bitcoin.txt", FileMode.Create);
            var streamwriter = new StreamWriter(filestream);
            streamwriter.AutoFlush = true;
            Console.SetOut(streamwriter);
            Console.SetError(streamwriter);

            timer();

            streamwriter.AutoFlush = false;

        }

        static void writeexcel()
        {
            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel._Workbook oWB;
            Microsoft.Office.Interop.Excel._Worksheet oSheet;
            Microsoft.Office.Interop.Excel.Range oRng;
            object misvalue = System.Reflection.Missing.Value;
            try
            {
                //Start Excel and get Application object.
                oXL = new Microsoft.Office.Interop.Excel.Application();
                oXL.Visible = true;
                oWB=oXL.Workbooks.Open("C:\\test\\test505.xls");

                //Get a new workbook.
                //oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Add(""));
                
                oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

                //Add table headers going cell by cell.
                oSheet.Cells[1, 1] = "First Name";
                oSheet.Cells[1, 2] = "Last Name";
                oSheet.Cells[1, 3] = "Full Name";
                oSheet.Cells[1, 4] = "Salary";

                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("A1", "D1").Font.Bold = true;
                oSheet.get_Range("A1", "D1").VerticalAlignment =
                    Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                // Create an array to multiple values at once.
                string[,] saNames = new string[5, 2];

                saNames[0, 0] = "John";
                saNames[0, 1] = "Smith";
                saNames[1, 0] = "Tom";

                saNames[4, 1] = "Johnson";

                //Fill A2:B6 with an array of values (First and Last Names).
                oSheet.get_Range("A2", "B6").Value2 = saNames;

                //Fill C2:C6 with a relative formula (=A2 & " " & B2).
                oRng = oSheet.get_Range("C2", "C6");
                oRng.Formula = "=A2 & \" \" & B2";

                //Fill D2:D6 with a formula(=RAND()*100000) and apply format.
                oRng = oSheet.get_Range("D2", "D6");
                oRng.Formula = "=RAND()*100000";
                oRng.NumberFormat = "$0.00";

                //AutoFit columns A:D.
                oRng = oSheet.get_Range("A1", "D1");
                oRng.EntireColumn.AutoFit();

                oXL.Visible = false;
                oXL.UserControl = false;
                oWB.Save();
                /*oWB.SaveAs("C:\\test\\test505.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
                    false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);*/

                oWB.Close();
            }
            catch
            {
                Console.WriteLine("error");
            }
        }

        static void timer()
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 50000;
            aTimer.Enabled = true;

            while (Console.Read() != 'q') ;
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Decision("XXBTZEUR");          
        }

        #endregion

        static string SplitJSON(string json, string elt, int position = 0)
        {
            string[] listjson;
            listjson = json.Split('"');
            string result="0000";
            for (int i = 0; i < listjson.Length;i++ )
            {
                if (listjson[i] == elt)
                {
                    result = /*listjson[i] + "=" +*/ listjson[i + 2+position ];
                }     
            }
                return result;
        }

        public static void PlaceOrder(ref KrakenOrder order, bool wait)
        {
            try
            {

                Console.WriteLine("Placing order...");

                var placeOrderResult = broker.PlaceOrder(ref order,wait);

                switch (placeOrderResult.ResultType)
                {
                    case PlaceOrderResultType.error:
                        Console.WriteLine("An error occured while placing the order");
                        foreach (var item in placeOrderResult.Errors)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case PlaceOrderResultType.success:
                        Console.WriteLine(string.Format("Succesfully placed order {0}", order.TxId));
                        break;
                    case PlaceOrderResultType.partial:
                        Console.WriteLine(string.Format("Partially filled order {0}. {1} of {2}", order.TxId, order.VolumeExecuted, order.Volume));
                        break;
                    case PlaceOrderResultType.txid_null:
                        Console.WriteLine(string.Format("Order was not placed. Unknown reason"));
                        break;
                    case PlaceOrderResultType.canceled_not_partial:
                        Console.WriteLine(string.Format("The order was cancelled. Reason: {0}", order.Reason));
                        break;
                    case PlaceOrderResultType.exception:
                        Console.WriteLine(string.Format("Something went wrong. {0}", placeOrderResult.Exception.Message));
                        break;
                    default:
                        Console.WriteLine(string.Format("unknown PlaceOrderResultType {0}", placeOrderResult.ResultType));
                        break;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong " + ex.Message);
                throw;
            }
        }

        public static void ClosePositionAndWaitForConfirmation(ref KrakenOrder openingOrder, decimal limitPrice)
        {

            try
            {
                Console.WriteLine("Closing position...");

                var closingOrder = broker.CreateClosingOrder(openingOrder, limitPrice, false);

                var closePositionResult = broker.PlaceOrder(ref closingOrder,true);

                switch (closePositionResult.ResultType)
                {
                    case PlaceOrderResultType.error:
                        Console.WriteLine("An error occured while placing the order");
                        foreach (var item in closePositionResult.Errors)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case PlaceOrderResultType.success:
                        Console.WriteLine(string.Format("Succesfully placed order {0}", closingOrder.TxId));
                        break;
                    case PlaceOrderResultType.partial:
                        Console.WriteLine(string.Format("Partially filled order {0}. {1} of {2}", closingOrder.TxId, closingOrder.VolumeExecuted, closingOrder.Volume));
                        break;
                    case PlaceOrderResultType.txid_null:
                        Console.WriteLine(string.Format("Order was not placed. Unknown reason"));
                        break;
                    case PlaceOrderResultType.canceled_not_partial:
                        Console.WriteLine(string.Format("The order was canceled. Reason: {0}", closingOrder.Reason));
                        break;
                    case PlaceOrderResultType.exception:
                        Console.WriteLine(string.Format("Something went wrong. {0}", closingOrder.Reason));
                        break;
                    default:
                        Console.WriteLine(string.Format("unknown PlaceOrderResultType {0}", closePositionResult.ResultType));
                        break;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Something went wrong. {0}", ex.Message));
                throw;
            }
        }

        public static void CancelOrder(ref KrakenOrder order)
        {
            try
            {

                Console.WriteLine("Cancelling order...");

                var cancelOrderResult = broker.CancelOrder(ref order);

                switch (cancelOrderResult.ResultType)
                {
                    case CancelOrderResultType.error:
                        Console.WriteLine("An error occured while cancelling the order");
                        foreach (var item in cancelOrderResult.Errors)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case CancelOrderResultType.success:
                        Console.WriteLine(string.Format("Succesfully cancelled order {0}", order.TxId));
                        break;
                    case CancelOrderResultType.exception:
                        Console.WriteLine(string.Format("Something went wrong. {0}", order.Reason));
                        break;
                    default:
                        Console.WriteLine(string.Format("unknown CancelOrderResultType {0}", cancelOrderResult.ResultType));
                        break;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong " + ex.Message);
                throw;
            }
        }
    }
}
