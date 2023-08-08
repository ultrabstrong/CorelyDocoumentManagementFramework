using Corely.Core;
using Corely.Data.Serialization;
using Corely.DocuWare;
using Corely.FC2DW;
using Corely.Kingstone;
using Corely.Kingstone.Core;
using Corely.Logging;
using Corely.Sage300HH2;
using Corely.Sage300HH2.Core;
using Corely.Sage300HH2.Core.Document;
using Corely.Security;
using Corely.Security.Authentication;
using DocuWare.Platform.ServerClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }


        #region FC Dataset Import With Corely Sample Scripts

        /// <summary>
        /// Base script for importing vendors
        /// </summary>
        static void VendorDataSetImportCode()
        {
            /*
            using System;
            using System.Collections.Generic;
            using Corely.Logging;
            using Corely.Data.Delimited;
            using Corely.Data.Culture;

            // Create file logger for writing to file
            FileLogger logger = new FileLogger("Vendor Import", @"C:\ProgramData\AbbyyAddins\", "DataSetImportLog") { LogLevel = LogLevel.WARN };
            try
            {
                // Create country code lookup
                CountryTagLookup lookup = new CountryTagLookup();
                lookup.Corrections.Add("", "USA");
                // Create list of CSV files to import
                List<string> csvFiles = new List<string>()
                {
                    @"C:\FlexiCapture.in\vendors.csv"
                };
                // Iterate CSV files and import them
                foreach (string csvFile in csvFiles)
                {
                    // Read and parse files
                    DelimitedReader dr = new DelimitedReader();
                    List<ReadRecordResult> results = dr.ReadAllFileRecords(csvFile);
                    // Iterate file records and add them to dataset
                    for (int i = 1; i < results.Count; i++)
                    {
                        try
                        {
                            // Create record and add values
                            IDataSetRecord record = DataSet.CreateRecord();
                            record.AddValue("Id", results[i].Tokens[1]);
                            record.AddValue("Name", results[i].Tokens[2]);
                            record.AddValue("Street", results[i].Tokens[3]);
                            record.AddValue("Street", results[i].Tokens[4]);
                            record.AddValue("Street", results[i].Tokens[5]);
                            record.AddValue("City", results[i].Tokens[6]);
                            record.AddValue("State", results[i].Tokens[7]);
                            record.AddValue("ZIP", results[i].Tokens[8]);
                            record.AddValue("CountryCode", lookup.GetTwoLetterName(results[i].Tokens[9] ?? ""));
                            record.AddValue("BusinessUnitId", results[i].Tokens[12]);
                            record.AddValue("GLCode", results[i].Tokens[10]);
                            record.AddValue("Terms", results[i].Tokens[11]);
                            record.AddValue("Division", results[i].Tokens[13]);
                            DataSet.AddRecord(record);
                        }
                        catch (Exception ex)
                        {
                            // Output failed record to log
                            DelimitedWriter dw = new DelimitedWriter();
                            logger.WriteLog("Failed to create data record", dw.WriteRecordToString(results[i].Tokens), LogLevel.NOTICE);
                            logger.WriteLog("Error while creating data record", ex, LogLevel.ERROR);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log exception to file and throw
                logger.WriteLog("Failed to execute script", ex, LogLevel.ERROR);
                throw;
            }
            */
        }

        /// <summary>
        /// Base script for importing GLs from a large file
        /// </summary>
        static void LargeGLDataSetImportCode()
        {
            /*
            using System;
            using System.Collections.Generic;
            using Corely.Logging;
            using Corely.Data.Delimited;
            using Corely.Data.Culture;

            // Create file logger for writing to file
            FileLogger logger = new FileLogger("GL Import", @"C:\ProgramData\AbbyyAddins\", "DataSetImportLog") { LogLevel = LogLevel.WARN };
            try
            {
                // Create list of CSV files to import
                List<string> csvFiles = new List<string>()
                {
                    @"C:\FlexiCapture.IN\accounts-all.csv",
                    @"C:\FlexiCapture.IN\accounts-cpr.csv"
                };
                // Iterate CSV files and import them
                foreach (string csvFile in csvFiles)
                {
                    logger.WriteLog("Reading file", csvFile, LogLevel.DEBUG);
                    // Read in header record
                    DelimitedReader dr = new DelimitedReader();
                    ReadRecordResult result = dr.ReadFileRecord(0, csvFile);
                    do
                    {
                        try
                        {
                            // Get next result
                            logger.WriteLog("Reading result position", result.EndPosition.ToString(), LogLevel.DEBUG);
                            result = dr.ReadFileRecord(result.EndPosition, csvFile);
                            // Create record and add values
                            IDataSetRecord record = DataSet.CreateRecord();
                            record.AddValue("Location", result.Tokens[0]);
                            record.AddValue("GLCode", result.Tokens[1]);
                            record.AddValue("GLDescription", result.Tokens[2]);
                            DataSet.AddRecord(record);
                        }
                        catch (Exception ex)
                        {
                            // Output failed record to log
                            DelimitedWriter dw = new DelimitedWriter();
                            logger.WriteLog("Failed to create data record", dw.WriteRecordToString(result.Tokens), LogLevel.NOTICE);
                            logger.WriteLog("Error while creating data record", ex, LogLevel.ERROR);
                        }
                    }
                    while (result.HasMore);
                }
            }
            catch (Exception ex)
            {
                // Log exception to file and throw
                logger.WriteLog("Failed to execute script", ex, LogLevel.ERROR);
                throw;
            }
            */
        }

        /// <summary>
        /// Base script for importing datasets in cloud environments
        /// </summary>
        static void CloudDataSetImportcode()
        {
            /*
            using System;
            using System.Collections.Generic;
            using Corely.Logging;
            using Corely.Data.Delimited;

            try
            {
                // Create list of CSV files to import
                List<string> csvFiles = new List<string>()
                {
                    @"<path-to-csv-1>",
                    @"<path-to-csv-2>"
                };
                // Iterate CSV files and import them
                foreach (string csvFile in csvFiles)
                {
                    if(System.IO.File.Exists(csvFile))
                    {
                        // Read and parse files
                        DelimitedReader dr = new DelimitedReader();
                        List<ReadRecordResult> results = dr.ReadAllFileRecords(csvFile);
                        // Iterate file records and add them to dataset
                        for (int i = 0; i < results.Count; i++)
                        {
                            // Create record and add values
                            IDataSetRecord record = DataSet.CreateRecord();
                            record.AddValue("Counterparties", results[i].Tokens[1]);
                            record.AddValue("VendorID", results[i].Tokens[0]);
                            DataSet.AddRecord(record);
                        }
                    }
                    else
                    {
                        FCTools.ShowMessage("File does not exist: " + csvFile);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log exception to file and throw
                FCTools.ShowMessage("Import Failed - " + ex.Message);
                throw;
            }
            */
        }

        /// <summary>
        /// Base script for importing large datasets in cloud environments
        /// </summary>
        static void CloudLargeDataSetImportCode()
        {
            /*
            using System;
            using System.Collections.Generic;
            using Corely.Logging;
            using Corely.Data.Delimited;

            try
            {
                // Create list of CSV files to import
                List<string> csvFiles = new List<string>()
                {
                    @"<path-to-csv-1>",
                    @"<path-to-csv-2>"
                };
                // Iterate CSV files and import them
                foreach (string csvFile in csvFiles)
                {
                    if(System.IO.File.Exists(csvFile))
                    {
                        // Read in header record
                        DelimitedReader dr = new DelimitedReader();
                        ReadRecordResult result = dr.ReadFileRecord(0, csvFile);
                        int recordId = 1;
                        do
                        {
                            try
                            {
                                // Read in next data record
                                result = dr.ReadFileRecord(result.EndPosition, csvFile);
                                recordId++;
                                // Create record and add values
                                IDataSetRecord record = DataSet.CreateRecord();
                                record.AddValue("Counterparties", result.Tokens[1]);
                                record.AddValue("VendorID", result.Tokens[0]);
                                DataSet.AddRecord(record);
                            }
                            catch(Exception ex)
                            {
                                FCTools.ShowMessage("Failed to import record " + recordId.ToString());
                                FCTools.ShowMessage(ex.Message);
                            }
                        }
                        while (result.HasMore);
                    }
                    else
                    {
                        FCTools.ShowMessage("File does not exist: " + csvFile);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log exception to file and throw
                FCTools.ShowMessage("Import Failed - " + ex.Message);
                throw;
            }
            */
        }

        #endregion

        #region Sage HH2 Tests

        /// <summary>
        /// Create and return sage connection
        /// </summary>
        /// <returns></returns>
        static SageHH2Connection GetSageConnection()
        {
            // Create base connection
            SageHH2Connection connection = new SageHH2Connection();
            // Connect and disconnect
            connection.Connect();
            return connection;
        }

        /// <summary>
        /// Test connection to Sage HH2
        /// </summary>
        static void TestSageConnection()
        {
            SageHH2Connection connection = GetSageConnection();
            bool isconnected = connection.IsConnected();
            connection.Disconnect();
            // Serialize and deserialize
            string xml = XmlSerializer.Serialize(connection);
            connection = XmlSerializer.DeSerialize<SageHH2Connection>(xml);
            // Connect and disconnect again with deserialized connection
            connection.Connect();
            isconnected = connection.IsConnected();
            connection.Disconnect();
            ;
        }

        /// <summary>
        /// Test getting data from sage
        /// </summary>
        static void TestSageGetMethods()
        {
            // Create base connection
            SageHH2Connection connection = GetSageConnection();
            // Run 'get all' methods
            List<Account> accounts = connection.GetAllAccounts();
            List<CostCode> costcodes = connection.GetAllCostCodes();
            List<Category> categories = connection.GetAllCategories();
            List<StandardCategory> standardcategories = connection.GetAllStandardCategories();
            List<Corely.Sage300HH2.Core.Payment> payment = connection.GetAllPayments();
            List<Corely.Sage300HH2.Core.Payment> payments = connection.GetPaymentsForVendorIdAndInvoiceCode("ven-id", "inv-code");
            List<Corely.Sage300HH2.Core.Distribution> distributions = connection.GetAllDistributions();
            List<Job> jobs = connection.GetAllJobs();
            string jobcode = "";
            foreach (Job job in jobs)
            {
                job.Categories = connection.GetCategoriesForJobId(job.Id);
                if (job.Categories != null)
                {
                    jobcode = job.Code;
                    break;
                }
            }
            // Get one job
            Job j = connection.GetJobForJobCode(jobcode);
            j.Categories = connection.GetCategoriesForJobId(j.Id);
            // Get all invoices
            List<Invoice> invoices = connection.GetAllAPInvoices();
            Invoice inv = null;
            foreach (Invoice invoice in invoices)
            {
                invoice.Distribution = connection.GetDistributionsForInvoiceId(invoice.Id);
                if (invoice.Distribution != null)
                {
                    inv = invoice;
                    break;
                }
            }
        }

        /// <summary>
        /// Test sage auto-category default
        /// </summary>
        static void TestSageAutoCategory()
        {
            SageHH2Connection connection = GetSageConnection();
            // Cost code without category
            string costcodecode = "cost-code-code";
            string jobcode = "job-code";
            Job job = connection.GetJobForJobCode(jobcode);
            CostCode code = connection.GetCostCodeForJobIdAndCostCodeCode(job.Id, costcodecode);
            bool isvalid = code != null;
            job.Categories = connection.GetCategoriesForJobId(job.Id);
            List<Category> category = connection.GetCategoriesForJobIdAndCostCodeId(job.Id, code.Id);
            ;
        }

        /// <summary>
        /// Test updating HH2 document
        /// </summary>
        static void TestSageUpdate()
        {
            DateTime start = DateTime.UtcNow;
            string requeststr = "{json-request-string}";
            string docid = "doc-id";
            UpdateDocumentRequest request = JsonConvert.DeserializeObject<UpdateDocumentRequest>(requeststr);
            SageHH2Connection connection = GetSageConnection();

            connection.UpdateDocument(request, docid);
            // Check for errors from export
            connection.ThrowExceptionsForDocument(docid, start);
        }

        /// <summary>
        /// Test posting data to sage
        /// </summary>
        static void TestSagePostMethods()
        {
            string requeststr = "{json-request-string}";

            // Create JSON document request
            CreateDocumentRequest request = JsonConvert.DeserializeObject<CreateDocumentRequest>(requeststr);

            /// POST CODE ====================================

            // Get Sage HH2 Connection
            SageHH2Connection connection = GetSageConnection();
            string docid = "";
            DateTime start = DateTime.UtcNow;
            try
            {
                // Post document to HH2
                docid = connection.WriteDocument(request);

                // Check for errors from posting
                connection.ThrowExceptionsForDocument(docid, start);

                // Export from HH2 to Sage
                string operationid = connection.ExportDocument(docid);

                // Wait for opration to complete
                connection.WaitForHH2Operation(operationid, 200);

                // Check for errors from export
                connection.ThrowExceptionsForDocument(docid, start);
            }
            catch
            {
                if (!string.IsNullOrWhiteSpace(docid))
                {
                    start = DateTime.UtcNow;
                    // Get corrected category and update document
                    UpdateDocumentRequest updaterequest = new UpdateDocumentRequest()
                    {
                        Snapshot = request.Snapshot,
                        ActionLevel = 1,
                        UpdatedOn = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")
                    };
                    updaterequest.Snapshot.Distributions[0].CategoryId = "category-id";
                    connection.UpdateDocument(updaterequest, docid);
                    // Check for errors from export
                    connection.ThrowExceptionsForDocument(docid, start);
                }
                else
                {
                    throw;
                }
            }
        }

        #endregion

        #region Kingstone Tests

        /// <summary>
        /// Create and return kingstone connection
        /// </summary>
        /// <returns></returns>
        static KingstoneConnection GetKingstoneConnection()
        {
            // Create base connection
            KingstoneConnection connection = new KingstoneConnection();
            // Connect and return
            connection.Connect();
            return connection;
        }

        /// <summary>
        /// Test get methods for kingstone
        /// </summary>
        static void TestKingstoneGetMethods()
        {
            KingstoneConnection connection = GetKingstoneConnection();
            List<Policy> policies = connection.GetAllPolicies();
            ;
        }

        /// <summary>
        /// Test post methods for kingstone
        /// </summary>
        static void TestKingstonePostMethods()
        {
            KingstoneConnection connection = GetKingstoneConnection();
            Corely.Kingstone.Core.Payment payment = new Corely.Kingstone.Core.Payment();
            string paymentid = connection.PostPayment(payment);
            Console.WriteLine(paymentid);
        }

        #endregion

        #region FC2DW Tests

        /// <summary>
        /// Test the DocuWare search and doc display
        /// </summary>
        static void TestDWSearch()
        {
            FileLogger logger = new FileLogger("DW Search", @"C:\ProgramData\AbbyyAddins\", "LogFile") { LogLevel = LogLevel.WARN };
            // Create setings for searching document
            DWSearchSettings settings = new DWSearchSettings()
            {
                Credentials = new GeneralCredentials()
                {
                    Host = "https://your-dw-instance",
                    Username = "un",
                    Password = new AESValue("pw", AESEncryption.CreateRandomBase64Key())
                },
                FileCabinetGuid = "cabinet-guid",
                SearchValues = new NamedValues(new Dictionary<string, string>()
                {
                    { "search_field", "search_value" }
                })
            };
            ResultBase result = settings.LookupDWDocument(logger);
            if (!result.Succeeded)
            {
                Console.WriteLine(result.Message);
            }
        }

        #endregion

        #region FC2DW Sample Scripts

        /// <summary>
        /// Sample upload to DW script
        /// </summary>
        static void UploadFromFCToDWSample()
        {
            /*
            using System;
            using System.Collections.Generic;
            using Corely.Logging;
            using Corely.FC2DW;

            // Create file logger for writing to file
            FileLogger logger = new FileLogger("DocuWare Export", @"C:\ProgramData\AbbyyAddins\", "ExportLog") { LogLevel = LogLevel.WARN };
            try
            {
                Exporter settings = new Exporter()
                {
                    DWServer = "https://TBD.docuware.cloud",
                    DWUsername = "un",
                    DWPassword = "pw",
                    DWFCID = "TBD",
                    Logger = logger
                };


                // Create header field mappings
                settings.HeaderFieldMapping = new Dictionary<string, string>();
                settings.HeaderFieldMapping.Add("VENDOR_ID", @"Vendor\VendorId");
                settings.HeaderFieldMapping.Add("VENDOR_NAME", @"Vendor\Name");
                settings.HeaderFieldMapping.Add("STORE__", @"StoreNumber");
                settings.HeaderFieldMapping.Add("INVOICE_NUMBER", @"InvoiceNumber");
                settings.HeaderFieldMapping.Add("TOTAL", @"Total");
                settings.HeaderFieldMapping.Add("INVOICE_DUE_DATE", @"InvoiceData\DueDate");
                settings.HeaderFieldMapping.Add("PURCHASE_ORDER_NUMBER", @"InvoiceData\PurchaserName");
                settings.HeaderFieldMapping.Add("INVOICE_DATE", @"InvoiceDate");
                settings.HeaderFieldMapping.Add("WORKFLOW_NAME", @"Workflow");
                settings.HeaderFieldMapping.Add("TAXES", @"SalesTax");
                // Create keyword mapping 
                settings.ColumnToKeywordMapping = new List<ColumnToKeywordMapping>()
                {
                    new ColumnToKeywordMapping()
                    {
                        FlexiTableColumn = "",
                        FlexiTableName = "",
                        KeywordFieldName = ""
                    }
                };
                // Create fixed keyword
                settings.FixedKeywordMappings = new List<FixedKeywordMapping>()
                {
                    new FixedKeywordMapping()
                    {
                        KeywordFieldName = "",
                        Keywords = new List<string>() { "" }
                    }
                };
                // Create header fixed fields
                settings.HeaderFixedFields = new Dictionary<string, string>();
                settings.HeaderFixedFields.Add("DOCUMENT_TYPE", "Invoice");
                settings.HeaderFixedFields.Add("STATUS", "New");
                // Create table field mappings
                settings.TableMapping = new TableMapping();
                settings.TableMapping.FlexiTableName = "LineItems";
                settings.TableMapping.DWTableName = "GL_Code";
                settings.TableMapping.MappedColumns = new Dictionary<string, string>();
                settings.TableMapping.MappedColumns.Add("GL_CO_AMOUNT", @"TotalPriceNetto");
                settings.TableMapping.MappedColumns.Add("GL_CO_MAIN_GL_ACCOUNT_", @"GLCode");
                settings.TableMapping.MappedColumns.Add("GL_CO_STORE_NUMBER", @"CostCenter");
                settings.TableMapping.MappedColumns.Add("GL_CO_SALES_TAX", @"SalesTax");
                settings.TableMapping.MappedColumns.Add("GL_CO_COMMENTS1", @"Comment");
                // Create fixed table mappings
                settings.FixedTableMapping = new FixedTableMapping();
                settings.FixedTableMapping.DWTableName = "GL_Code";
                Dictionary<string, string> row = new Dictionary<string, string>();
                row.Add("dwcol1", "val1");
                row.Add("dwcol2", "val2");
                settings.FixedTableMapping.FixedRowColumnMapping.Add(row);
                // Create image saving options
                IExportImageSavingOptions options = FCTools.NewImageSavingOptions();
                options.Format = "pdf-s";
                options.UseMRC = true;
                options.ShouldOverwrite = true;
                // Map export to web service
                settings.UploadDocumentToServiceOverride += (postBody) =>
                {
                    // custom post logic here
                };
                // Run the export
                settings.ExportDocument(Document, options);
            }
            catch (Exception ex)
            {
                // Log exception to file and throw
                logger.WriteLog("Failed to execute script", ex, LogLevel.ERROR);
                throw;
            }
            */
        }

        /// <summary>
        /// Sample search DW script
        /// </summary>
        static void SearchDWFromFCSample()
        {
            /*
             * Use this script as a baseline for a custom button event for DocuWare searching
             *
            using System;
            using System.Collections.Generic;
            using Corely.Logging;
            using Corely.FC2DW;
            using Corely.Security;
            using Corely.Security.Authentication;

            // Make sure this command is the one for DocuWare searches
            if((ABBYY.FlexiCapture.ClientUI.TCommandID)CommandId == (ABBYY.FlexiCapture.ClientUI.TCommandID)1001)
            {
                // Make sure a document is currently open in the editor
                if(MainWindow.TaskWindow == null ||
                    MainWindow.TaskWindow.EditorWindow == null ||
                    MainWindow.TaskWindow.EditorWindow.Document == null)
                {
                    FCTools.ShowMessage("Open document first");
                }
                else
                {
                    // Create file logger for dw search
                    FileLogger logger = new FileLogger("DW Search", @"C:\ProgramData\AbbyyAddins\", "LogFile") { LogLevel = LogLevel.DEBUG };
                    try
                    {
                        // Create setings for searching document
                        DWSearchSettings settings = new DWSearchSettings()
                        {
                            Credentials = new GeneralCredentials()
                            {
                                Host = "https://yourplatform/DocuWare/Platform",
                                Username = "un",
                                Password = new AESValue("pw", AESEncryption.CreateRandomBase64Key())
                            },
                            FileCabinetGuid = "fcid",
                            SearchValues = new NamedValues(new Dictionary<string, string>()
                            {
                                { "field", "value" }
                            })
                        };
                        ResultBase result = settings.LookupDWDocument(logger);
                        // Check result from split. Show message if necessary
                        if(!result.Succeeded)
                        {
                            FCTools.ShowMessage(result.Message);
                            logger.WriteLog("DW search cancelled", "", LogLevel.WARN);
                        }
                    }
                    catch(Exception ex)
                    {
                        FCTools.ShowMessage("Error: " + ex.Message);
                        logger.WriteLog("Error searching", ex, LogLevel.ERROR);
                    }
                }
            }
            */
        }

        #endregion

        #region FlexiCapture Sample Scripts

        /// <summary>
        /// Line Split code for FC
        /// </summary>
        static void FlexicaptureLineSplitCode()
        {
            /*
             * Use this script as a baseline for a custom button event for line splits
             *
            using System;
            using System.Collections.Generic;
            using Corely.Core;
            using Corely.Distribution;
            using Corely.Logging;
            using Corely.FlexiCapture;
            using Corely.Data.Serialization;

            // Make sure this command is the one for line splits 
            if((ABBYY.FlexiCapture.ClientUI.TCommandID)CommandId == (ABBYY.FlexiCapture.ClientUI.TCommandID)1000)
            {
                // Make sure a document is currently open in the editor
                if(MainWindow.TaskWindow == null ||
                    MainWindow.TaskWindow.EditorWindow == null ||
                    MainWindow.TaskWindow.EditorWindow.Document == null)
                {
                    Message.Show("Open document first");
                }
                else
                {
                    // Save the document before proceeding
                    MainWindow.TaskWindow.EditorWindow.Save();
                    IDocument Document = MainWindow.TaskWindow.EditorWindow.Document;
                    MainWindow.TaskWindow.OpenDocument(Document);
                    // Create file logger for line splitting
                    FileLogger logger = new FileLogger("Line Split", @"C:\ProgramData\AbbyyAddins\", "LineSplitLog") { LogLevel = LogLevel.WARN };
                    try
                    {
                        // Create settings for splitting 
                        LineSplitSettings settings = new LineSplitSettings()
                        {
                            CopyFields = new List<string>() { "ArticleNumber", "Description", "MaterialNumber", "Store", "CostCenter", "UnitOfMeasurement", "UnitPrice", "Currency", "OrderItemId"},
                            SplitCheckField = "Split",
                            TotalPriceField = "TotalPriceNetto",
                            UnitPriceField = "UnitPrice",
                            QuantityField = "Quantity",
                            DistributionInsertAt = DistributionInsertAt.Current,
                            SplitOnTotal = true,
                            DistributionSettings = new DistributionSettings()
                        };
                        // Custom action to run on each line
                        Action<int, int> splitLineAction = (cursplit, insertat) => 
                        {
                            Document.Field("Invoice Layout\\LineItems").Items[insertat].Field("SplitXml").Text = XmlSerializer.Serialize(settings.DistributionSettings);
                            Document.Field("Invoice Layout\\LineItems").Items[cursplit].Field("LineItemUID").CheckRules();
                            string parentid = Document.Field("Invoice Layout\\LineItems").Items[cursplit].Field("LineItemUID").Text;
                            Document.Field("Invoice Layout\\LineItems").Items[insertat].Field("SplitParentUID").Text = parentid;
                        };
                        // Call method to perform split
                        ResultBase result = settings.ShowDistributionSettingsFromProjectAndSplit("lineSplitDistributionSettings", Document, logger, splitLineAction);
                        // Display result errors if any exist
                        result.DisplayErrors();
                    }
                    catch (Exception ex)
                    {
                        Message.Show("Error: " + ex.Message);
                        logger.WriteLog("FlexiCapture script error splitting Lines", ex, LogLevel.ERROR);
                    }
                }
            }
            */
        }

        #endregion

        #region DocuWare Tests

        /// <summary>
        /// Test docuware field conversion and serialization
        /// </summary>
        static void TestDWFieldConversion()
        {
            byte[] docBytes = new byte[100];
            string mimeType = "application/pdf";
            List<DocumentIndexField> newFields = new List<DocumentIndexField>()
                {
                    DocumentIndexField.Create("TEXT", "ASDF"),
                    DocumentIndexField.Create("DATE", DateTime.Now),
                    DocumentIndexField.Create("DECIMAL", 1.0m),
                    DocumentIndexField.Create("INT", 100),
                    DocumentIndexField.Create("TEXT", new DocumentIndexFieldKeywords() { Keyword = new List<string>() { "Value1", "Value2" } })
                };
            DocumentIndexFieldTable table = new DocumentIndexFieldTable();
            table.Row = new List<DocumentIndexFieldTableRow>();
            for (int i = 1; i < 4; i++)
            {
                DocumentIndexFieldTableRow row = new DocumentIndexFieldTableRow();
                row.ColumnValue = new List<DocumentIndexField>();
                row.ColumnValue.Add(DocumentIndexField.Create($"TEXT{i}", $"ASDF{i}"));
                row.ColumnValue.Add(DocumentIndexField.Create($"DATE{i}", DateTime.Now.AddDays(i)));
                row.ColumnValue.Add(DocumentIndexField.Create($"DECIMAL{i}", (decimal)i));
                table.Row.Add(row);
            }
            newFields.Add(new DocumentIndexField() { FieldName = "TABLE", ItemElementName = ItemChoiceType.Table, Item = table });
            DocumentData documentData = new DocumentData(docBytes, mimeType, newFields);
            //DocumentData documentData2 = DocumentData.FromJsonString(documentData.ToJsonString());
            DocumentData documentData2 = DocumentData.FromXmlString(documentData.ToXmlString());
            List<DocumentIndexField> newField2 = documentData2.GetDWFields();
            ;
        }

        #endregion

    }
}
