using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace DirRX.NonformalDocSmartProcessing.Module.SmartProcessing.Server
{
  partial class ModuleFunctions
  {
    public override Sungero.Docflow.IOfficialDocument CreateSupAgreement(Sungero.SmartProcessing.Structures.Module.IDocumentInfo documentInfo, Sungero.Company.IEmployee responsible)
    {
      Logger.Debug("CreateSupAgreement: Start.");
      
      // Доп.соглашение.
      var document = Sungero.Contracts.SupAgreements.Null;
      
      var currentDocId = DirRX.NonformalDocSmartProcessing.Blobs.As(documentInfo.ArioDocument.OriginalBlob).ExistingDocIdDirRX;
      if (currentDocId != null)
      {
        var officialDocument = Sungero.Docflow.OfficialDocuments.GetAll().Where(d => d.Id == currentDocId).FirstOrDefault();
        if (officialDocument != null)
        {
          var lockInfo = Locks.GetLockInfo(officialDocument);
          if (lockInfo != null && lockInfo.IsLockedByOther)
          {
            Logger.ErrorFormat("CreateSupAgreement: cannot lock document with Id ={0}, {1}", officialDocument.Id, lockInfo.LockedMessage);
            return officialDocument;
          }
          
          document = !Sungero.Contracts.SupAgreements.Is(officialDocument) ?
            Sungero.Contracts.SupAgreements.As(officialDocument.ConvertTo(Sungero.Contracts.SupAgreements.Info)) :
            Sungero.Contracts.SupAgreements.As(officialDocument);
        }
      }
      else
        document = Sungero.Contracts.SupAgreements.Create();
      
      if (documentInfo.IsFuzzySearchEnabled)
        this.FillSupAgreementPropertiesFuzzy(document, documentInfo, responsible);
      else
        this.FillSupAgreementProperties(document, documentInfo, responsible);
      
      foreach (var property in document.State.Properties)
        property.IsRequired = false;
      
      Logger.Debug("CreateSupAgreement: End.");
      
      return document;
    }
    
    public override Sungero.Docflow.IOfficialDocument CreateWaybill(Sungero.SmartProcessing.Structures.Module.IDocumentInfo documentInfo, Sungero.Company.IEmployee responsible)
    {
      Logger.Debug("CreateWaybill: Start.");
      
      // Товарная накладная.
      var document = Sungero.FinancialArchive.Waybills.Null;
      
      var currentDocId = DirRX.NonformalDocSmartProcessing.Blobs.As(documentInfo.ArioDocument.OriginalBlob).ExistingDocIdDirRX;
      if (currentDocId != null)
      {
        var officialDocument = Sungero.Docflow.OfficialDocuments.GetAll().Where(d => d.Id == currentDocId).FirstOrDefault();
        if (officialDocument != null)
        {
          var lockInfo = Locks.GetLockInfo(officialDocument);
          if (lockInfo != null && lockInfo.IsLockedByOther)
          {
            Logger.ErrorFormat("CreateWaybill: cannot lock document with Id ={0}, {1}", officialDocument.Id, lockInfo.LockedMessage);
            return officialDocument;
          }
          
          document = !Sungero.FinancialArchive.Waybills.Is(officialDocument) ?
            Sungero.FinancialArchive.Waybills.As(officialDocument.ConvertTo(Sungero.FinancialArchive.Waybills.Info)) :
            Sungero.FinancialArchive.Waybills.As(officialDocument);
        }
      }
      else
        document = Sungero.FinancialArchive.Waybills.Create();
      
      if (documentInfo.IsFuzzySearchEnabled)
        this.FillWaybillPropertiesFuzzy(document, documentInfo, responsible);
      else
        this.FillWaybillProperties(document, documentInfo, responsible);
      
      foreach (var property in document.State.Properties)
        property.IsRequired = false;
      
      Logger.Debug("CreateWaybill: End.");
      
      return document;
    }
    
    public override Sungero.Docflow.IOfficialDocument CreateUniversalTransferDocument(Sungero.SmartProcessing.Structures.Module.IDocumentInfo documentInfo, Sungero.Company.IEmployee responsible)
    {
      Logger.Debug("CreateUniversalTransferDocument: Start.");
      
      // УПД.
      var document = Sungero.FinancialArchive.UniversalTransferDocuments.Null;
      
      var currentDocId = DirRX.NonformalDocSmartProcessing.Blobs.As(documentInfo.ArioDocument.OriginalBlob).ExistingDocIdDirRX;
      if (currentDocId != null)
      {
        var officialDocument = Sungero.Docflow.OfficialDocuments.GetAll().Where(d => d.Id == currentDocId).FirstOrDefault();
        if (officialDocument != null)
        {
          var lockInfo = Locks.GetLockInfo(officialDocument);
          if (lockInfo != null && lockInfo.IsLockedByOther)
          {
            Logger.ErrorFormat("CreateUniversalTransferDocument: cannot lock document with Id ={0}, {1}", officialDocument.Id, lockInfo.LockedMessage);
            return officialDocument;
          }
          
          document = !Sungero.FinancialArchive.UniversalTransferDocuments.Is(officialDocument) ?
            Sungero.FinancialArchive.UniversalTransferDocuments.As(officialDocument.ConvertTo(Sungero.FinancialArchive.UniversalTransferDocuments.Info)) :
            Sungero.FinancialArchive.UniversalTransferDocuments.As(officialDocument);
        }
      }
      else
        document = Sungero.FinancialArchive.UniversalTransferDocuments.Create();
      
      if (documentInfo.IsFuzzySearchEnabled)
        this.FillUniversalTransferDocumentPropertiesFuzzy(document, documentInfo, responsible);
      else
        this.FillUniversalTransferDocumentProperties(document, documentInfo, responsible);
      
      foreach (var property in document.State.Properties)
        property.IsRequired = false;
      
      Logger.Debug("CreateUniversalTransferDocument: End.");
      
      return document;
    }
    
    public override Sungero.Docflow.IOfficialDocument CreateUniversalTransferCorrectionDocument(Sungero.SmartProcessing.Structures.Module.IDocumentInfo documentInfo, Sungero.Company.IEmployee responsible)
    {
      Logger.Debug("CreateUniversalTransferCorrectionDocument: Start.");
      
      // УКД.
      var document = Sungero.FinancialArchive.UniversalTransferDocuments.Null;
      
      var currentDocId = DirRX.NonformalDocSmartProcessing.Blobs.As(documentInfo.ArioDocument.OriginalBlob).ExistingDocIdDirRX;
      if (currentDocId != null)
      {
        var officialDocument = Sungero.Docflow.OfficialDocuments.GetAll().Where(d => d.Id == currentDocId).FirstOrDefault();
        if (officialDocument != null)
        {
          var lockInfo = Locks.GetLockInfo(officialDocument);
          if (lockInfo != null && lockInfo.IsLockedByOther)
          {
            Logger.ErrorFormat("CreateUniversalTransferCorrectionDocument: cannot lock document with Id ={0}, {1}", officialDocument.Id, lockInfo.LockedMessage);
            return officialDocument;
          }
          
          document = !Sungero.FinancialArchive.UniversalTransferDocuments.Is(officialDocument) ?
            Sungero.FinancialArchive.UniversalTransferDocuments.As(officialDocument.ConvertTo(Sungero.FinancialArchive.UniversalTransferDocuments.Info)) :
            Sungero.FinancialArchive.UniversalTransferDocuments.As(officialDocument);
        }
      }
      else
        document = Sungero.FinancialArchive.UniversalTransferDocuments.Create();
      
      document.IsAdjustment = true;
      
      if (documentInfo.IsFuzzySearchEnabled)
        this.FillUniversalTransferDocumentPropertiesFuzzy(document, documentInfo, responsible);
      else
        this.FillUniversalTransferDocumentProperties(document, documentInfo, responsible);
      
      foreach (var property in document.State.Properties)
        property.IsRequired = false;
      
      Logger.Debug("CreateUniversalTransferCorrectionDocument: End.");
      
      return document;
    }
    public override Sungero.Docflow.IOfficialDocument CreateTaxInvoice(Sungero.SmartProcessing.Structures.Module.IDocumentInfo documentInfo, Sungero.Company.IEmployee responsible)
    {
      Logger.Debug("CreateTaxInvoice: Start.");
      
      var defaultBusinessUnit = this.GetBusinessUnit(documentInfo);
      var documentParties = Sungero.SmartProcessing.Structures.Module.RecognizedDocumentParties.Create();
      if (documentInfo.IsFuzzySearchEnabled)
      {
        this.SplitLegalFormAndName(documentInfo.ArioDocument, Sungero.SmartProcessing.Constants.Module.ArioGrammars.CounterpartyFact.Name,
                                   Sungero.SmartProcessing.Constants.Module.ArioGrammars.CounterpartyFact.NameField);
        documentParties = this.GetRecognizedTaxInvoicePartiesFuzzy(documentInfo.ArioDocument.Facts, defaultBusinessUnit);
      }
      else
      {
        documentParties = this.GetRecognizedTaxInvoiceParties(documentInfo.ArioDocument.Facts, defaultBusinessUnit);
      }
      
      var currentDocId = DirRX.NonformalDocSmartProcessing.Blobs.As(documentInfo.ArioDocument.OriginalBlob).ExistingDocIdDirRX;
      
      if (documentParties.IsDocumentOutgoing.Value == true)
      {
        var document = Sungero.FinancialArchive.OutgoingTaxInvoices.Null;
        
        if (currentDocId != null)
        {
          var officialDocument = Sungero.Docflow.OfficialDocuments.GetAll().Where(d => d.Id == currentDocId).FirstOrDefault();
          if (officialDocument != null)
          {
            var lockInfo = Locks.GetLockInfo(officialDocument);
            if (lockInfo != null && lockInfo.IsLockedByOther)
            {
              Logger.ErrorFormat("CreateTaxInvoice: OutgoingTaxInvoices cannot lock document with Id ={0}, {1}", officialDocument.Id, lockInfo.LockedMessage);
              return officialDocument;
            }
            
            document = !Sungero.FinancialArchive.OutgoingTaxInvoices.Is(officialDocument) ?
              Sungero.FinancialArchive.OutgoingTaxInvoices.As(officialDocument.ConvertTo(Sungero.FinancialArchive.OutgoingTaxInvoices.Info)) :
              Sungero.FinancialArchive.OutgoingTaxInvoices.As(officialDocument);
          }
        }
        else
          document = Sungero.FinancialArchive.OutgoingTaxInvoices.Create();
        
        this.FillOutgoingTaxInvoiceProperties(document, documentInfo, responsible, documentParties);
        
        Logger.Debug("CreateTaxInvoice: OutgoingTaxInvoices. End.");
        
        return document;
      }
      else
      {
        var document = Sungero.FinancialArchive.IncomingTaxInvoices.Null;
        
        if (currentDocId != null)
        {
          var officialDocument = Sungero.Docflow.OfficialDocuments.GetAll().Where(d => d.Id == currentDocId).FirstOrDefault();
          if (officialDocument != null)
          {
            var lockInfo = Locks.GetLockInfo(officialDocument);
            if (lockInfo != null && lockInfo.IsLockedByOther)
            {
              Logger.ErrorFormat("CreateTaxInvoice: IncomingTaxInvoices cannot lock document with Id ={0}, {1}", officialDocument.Id, lockInfo.LockedMessage);
              return officialDocument;
            }
            
            document = !Sungero.FinancialArchive.IncomingTaxInvoices.Is(officialDocument) ?
              Sungero.FinancialArchive.IncomingTaxInvoices.As(officialDocument.ConvertTo(Sungero.FinancialArchive.IncomingTaxInvoices.Info)) :
              Sungero.FinancialArchive.IncomingTaxInvoices.As(officialDocument);
          }
        }
        else
          document = Sungero.FinancialArchive.IncomingTaxInvoices.Create();
        
        this.FillIncomingTaxInvoiceProperties(document, documentInfo, responsible, documentParties);
        
        foreach (var property in document.State.Properties)
          property.IsRequired = false;
        
        Logger.Debug("CreateTaxInvoice: IncomingTaxInvoices. End.");
        
        return document;
      }
    }
    
    public override Sungero.Docflow.IOfficialDocument CreateTaxInvoiceCorrection(Sungero.SmartProcessing.Structures.Module.IDocumentInfo documentInfo, Sungero.Company.IEmployee responsible)
    {
      Logger.Debug("CreateTaxInvoiceCorrection: Start.");
      
      var documentParties = Sungero.SmartProcessing.Structures.Module.RecognizedDocumentParties.Create();
      var defaultBusinessUnit = this.GetBusinessUnit(documentInfo);
      if (documentInfo.IsFuzzySearchEnabled)
      {
        this.SplitLegalFormAndName(documentInfo.ArioDocument, Sungero.SmartProcessing.Constants.Module.ArioGrammars.CounterpartyFact.Name,
                                   Sungero.SmartProcessing.Constants.Module.ArioGrammars.CounterpartyFact.NameField);
        documentParties = this.GetRecognizedTaxInvoicePartiesFuzzy(documentInfo.ArioDocument.Facts, defaultBusinessUnit);
      }
      else
      {
        documentParties = this.GetRecognizedTaxInvoiceParties(documentInfo.ArioDocument.Facts, defaultBusinessUnit);
      }
      
      var currentDocId = DirRX.NonformalDocSmartProcessing.Blobs.As(documentInfo.ArioDocument.OriginalBlob).ExistingDocIdDirRX;
      
      if (documentParties.IsDocumentOutgoing.Value == true)
      {
        var document = Sungero.FinancialArchive.OutgoingTaxInvoices.Null;
        
        if (currentDocId != null)
        {
          var officialDocument = Sungero.Docflow.OfficialDocuments.GetAll().Where(d => d.Id == currentDocId).FirstOrDefault();
          if (officialDocument != null)
          {
            var lockInfo = Locks.GetLockInfo(officialDocument);
            if (lockInfo != null && lockInfo.IsLockedByOther)
            {
              Logger.ErrorFormat("CreateTaxInvoiceCorrection: OutgoingTaxInvoices cannot lock document with Id ={0}, {1}", officialDocument.Id, lockInfo.LockedMessage);
              return officialDocument;
            }
            
            document.IsAdjustment = true;
            
            document = !Sungero.FinancialArchive.OutgoingTaxInvoices.Is(officialDocument) ?
              Sungero.FinancialArchive.OutgoingTaxInvoices.As(officialDocument.ConvertTo(Sungero.FinancialArchive.OutgoingTaxInvoices.Info)) :
              Sungero.FinancialArchive.OutgoingTaxInvoices.As(officialDocument);
          }
        }
        else
          document = Sungero.FinancialArchive.OutgoingTaxInvoices.Create();
        
        document.IsAdjustment = true;
        
        this.FillOutgoingTaxInvoiceProperties(document, documentInfo, responsible, documentParties);
        
        Logger.Debug("CreateTaxInvoiceCorrection: OutgoingTaxInvoices. End.");
        
        return document;
      }
      else
      {
        var document = Sungero.FinancialArchive.IncomingTaxInvoices.Null;
        
        if (currentDocId != null)
        {
          var officialDocument = Sungero.Docflow.OfficialDocuments.GetAll().Where(d => d.Id == currentDocId).FirstOrDefault();
          if (officialDocument != null)
          {
            var lockInfo = Locks.GetLockInfo(officialDocument);
            if (lockInfo != null && lockInfo.IsLockedByOther)
            {
              Logger.ErrorFormat("CreateTaxInvoiceCorrection: IncomingTaxInvoices cannot lock document with Id ={0}, {1}", officialDocument.Id, lockInfo.LockedMessage);
              return officialDocument;
            }
            
            document.IsAdjustment = true;
            
            document = !Sungero.FinancialArchive.IncomingTaxInvoices.Is(officialDocument) ?
              Sungero.FinancialArchive.IncomingTaxInvoices.As(officialDocument.ConvertTo(Sungero.FinancialArchive.IncomingTaxInvoices.Info)) :
              Sungero.FinancialArchive.IncomingTaxInvoices.As(officialDocument);
          }
        }
        else
          document = Sungero.FinancialArchive.IncomingTaxInvoices.Create();
        
        document.IsAdjustment = true;
        
        this.FillIncomingTaxInvoiceProperties(document, documentInfo, responsible, documentParties);
        
        foreach (var property in document.State.Properties)
          property.IsRequired = false;
        
        Logger.Debug("CreateTaxInvoiceCorrection: IncomingTaxInvoices. End.");
        
        return document;
      }
    }
    
    public override Sungero.Docflow.IOfficialDocument CreateSimpleDocument(Sungero.SmartProcessing.Structures.Module.IDocumentInfo documentInfo, Sungero.Company.IEmployee responsible)
    {
      Logger.Debug("CreateSimpleDocument: Start.");
      
      var document = Sungero.Docflow.SimpleDocuments.Null;
      var currentDocId = DirRX.NonformalDocSmartProcessing.Blobs.As(documentInfo.ArioDocument.OriginalBlob).ExistingDocIdDirRX;
      
      if (currentDocId != null)
        return document;
      
      // Все нераспознанные документы создать простыми.
      document = Sungero.Docflow.SimpleDocuments.Create();
      
      // Имя документа сделать шаблонным, чтобы не падало сохранение, т.к. это свойство обязательное у документа.
      // Заполнение нужным значением будет выполнено в RenameNotClassifiedDocuments.
      var documentName = Resources.SimpleDocumentName;
      
      this.FillSimpleDocumentProperties(document, documentInfo, responsible, documentName);
      
      Logger.Debug("CreateSimpleDocument: End.");
      
      return document;
    }

    public override Sungero.Docflow.IOfficialDocument CreateIncomingLetter(Sungero.SmartProcessing.Structures.Module.IDocumentInfo documentInfo, Sungero.Company.IEmployee responsible)
    {
      Logger.Debug("CreateIncomingLetter: Start.");
      
      // Входящее письмо.
      var document = Sungero.RecordManagement.IncomingLetters.Null;
      
      var currentDocId = DirRX.NonformalDocSmartProcessing.Blobs.As(documentInfo.ArioDocument.OriginalBlob).ExistingDocIdDirRX;
      if (currentDocId != null)
      {
        var officialDocument = Sungero.Docflow.OfficialDocuments.GetAll().Where(d => d.Id == currentDocId).FirstOrDefault();
        if (officialDocument != null)
        {
          var lockInfo = Locks.GetLockInfo(officialDocument);
          if (lockInfo != null && lockInfo.IsLockedByOther)
          {
            Logger.ErrorFormat("CreateIncomingLetter: cannot lock document with Id ={0}, {1}", officialDocument.Id, lockInfo.LockedMessage);
            return officialDocument;
          }
          document = !Sungero.RecordManagement.IncomingLetters.Is(officialDocument) ?
            Sungero.RecordManagement.IncomingLetters.As(officialDocument.ConvertTo(Sungero.RecordManagement.IncomingLetters.Info)) :
            Sungero.RecordManagement.IncomingLetters.As(officialDocument);
        }
      }
      else
        document = Sungero.RecordManagement.IncomingLetters.Create();
      
      if (documentInfo.IsFuzzySearchEnabled)
        this.FillIncomingLetterPropertiesFuzzy(document, documentInfo, responsible);
      else
        this.FillIncomingLetterProperties(document, documentInfo, responsible);
      
      foreach (var property in document.State.Properties)
        property.IsRequired = false;
      
      
      Logger.Debug("CreateIncomingLetter: End.");
      
      return document;
    }
    
    public override Sungero.Docflow.IOfficialDocument CreateIncomingInvoice(Sungero.SmartProcessing.Structures.Module.IDocumentInfo documentInfo, Sungero.Company.IEmployee responsible)
    {
      Logger.Debug("CreateIncomingInvoice: Start.");
      
      // Счет на оплату.
      var document = Sungero.Contracts.IncomingInvoices.Null;
      
      var currentDocId = DirRX.NonformalDocSmartProcessing.Blobs.As(documentInfo.ArioDocument.OriginalBlob).ExistingDocIdDirRX;
      if (currentDocId != null)
      {
        var officialDocument = Sungero.Docflow.OfficialDocuments.GetAll().Where(d => d.Id == currentDocId).FirstOrDefault();
        if (officialDocument != null)
        {
          var lockInfo = Locks.GetLockInfo(officialDocument);
          if (lockInfo != null && lockInfo.IsLockedByOther)
          {
            Logger.ErrorFormat("CreateIncomingInvoice: cannot lock document with Id ={0}, {1}", officialDocument.Id, lockInfo.LockedMessage);
            return officialDocument;
          }
          
          document = !Sungero.Contracts.IncomingInvoices.Is(officialDocument) ?
            Sungero.Contracts.IncomingInvoices.As(officialDocument.ConvertTo(Sungero.Contracts.IncomingInvoices.Info)) :
            Sungero.Contracts.IncomingInvoices.As(officialDocument);
        }
      }
      else
        document = Sungero.Contracts.IncomingInvoices.Create();
      
      if (documentInfo.IsFuzzySearchEnabled)
        this.FillIncomingInvoicePropertiesFuzzy(document, documentInfo, responsible);
      else
        this.FillIncomingInvoiceProperties(document, documentInfo, responsible);
      
      Logger.Debug("CreateIncomingInvoice: End.");
      
      foreach (var property in document.State.Properties)
        property.IsRequired = false;
      
      return document;
    }
    
    public override Sungero.Docflow.IOfficialDocument CreateContractStatement(Sungero.SmartProcessing.Structures.Module.IDocumentInfo documentInfo, Sungero.Company.IEmployee responsible)
    {
      Logger.Debug("CreateContractStatement: Start.");
      
      // Акт выполненных работ.
      var document = Sungero.FinancialArchive.ContractStatements.Null;
      
      var currentDocId = DirRX.NonformalDocSmartProcessing.Blobs.As(documentInfo.ArioDocument.OriginalBlob).ExistingDocIdDirRX;
      if (currentDocId != null)
      {
        var officialDocument = Sungero.Docflow.OfficialDocuments.GetAll().Where(d => d.Id == currentDocId).FirstOrDefault();
        if (officialDocument != null)
        {
          var lockInfo = Locks.GetLockInfo(officialDocument);
          if (lockInfo != null && lockInfo.IsLockedByOther)
          {
            Logger.ErrorFormat("CreateContractStatement: cannot lock document with Id ={0}, {1}", officialDocument.Id, lockInfo.LockedMessage);
            return officialDocument;
          }
          
          document = !Sungero.FinancialArchive.ContractStatements.Is(officialDocument) ?
            Sungero.FinancialArchive.ContractStatements.As(officialDocument.ConvertTo(Sungero.FinancialArchive.ContractStatements.Info)) :
            Sungero.FinancialArchive.ContractStatements.As(officialDocument);
        }
      }
      else
        document = Sungero.FinancialArchive.ContractStatements.Create();
      
      if (documentInfo.IsFuzzySearchEnabled)
        this.FillContractStatementPropertiesFuzzy(document, documentInfo, responsible);
      else
        this.FillContractStatementProperties(document, documentInfo, responsible);
      
      foreach (var property in document.State.Properties)
        property.IsRequired = false;
      
      Logger.Debug("CreateContractStatement: End.");
      
      return document;
    }
    
    public override Sungero.Docflow.IOfficialDocument CreateContract(Sungero.SmartProcessing.Structures.Module.IDocumentInfo documentInfo, Sungero.Company.IEmployee responsible)
    {
      Logger.Debug("CreateContract: Start.");
      
      // Договор.
      var document = Sungero.Contracts.Contracts.Null;
      
      var currentDocId = DirRX.NonformalDocSmartProcessing.Blobs.As(documentInfo.ArioDocument.OriginalBlob).ExistingDocIdDirRX;
      if (currentDocId != null)
      {
        var officialDocument = Sungero.Docflow.OfficialDocuments.GetAll().Where(d => d.Id == currentDocId).FirstOrDefault();
        if (officialDocument != null)
        {
          var lockInfo = Locks.GetLockInfo(officialDocument);
          if (lockInfo != null && lockInfo.IsLockedByOther)
          {
            Logger.ErrorFormat("CreateContract: cannot lock document with Id ={0}, {1}", officialDocument.Id, lockInfo.LockedMessage);
            return officialDocument;
          }
          
          document = !Sungero.Contracts.Contracts.Is(officialDocument) ?
            Sungero.Contracts.Contracts.As(officialDocument.ConvertTo(Sungero.Contracts.Contracts.Info)) :
            Sungero.Contracts.Contracts.As(officialDocument);
        }
      }
      else
        document = Sungero.Contracts.Contracts.Create();
      
      if (documentInfo.IsFuzzySearchEnabled)
        this.FillContractPropertiesFuzzy(document, documentInfo, responsible);
      else
        this.FillContractProperties(document, documentInfo, responsible);
      
      foreach (var property in document.State.Properties)
        property.IsRequired = false;
      
      Logger.Debug("CreateContract: End.");
      
      return document;
    }
    
    /// <summary>
    /// Обработать пакет документов со сканера или почты.
    /// </summary>
    /// <param name="blobPackage">Пакет бинарных образов документов.</param>
    [Public]
    public virtual void ProcessCapturedPackage(Sungero.SmartProcessing.IBlobPackage blobPackage)
    {
      var arioPackage = this.UnpackArioPackage(blobPackage);
      
      var documentPackage = this.BuildDocumentPackage(blobPackage, arioPackage);
      
      this.OrderAndLinkDocumentPackage(documentPackage);
      
      if (documentPackage.CaptureSource?.IsSendTask == true)
        this.SendToResponsible(documentPackage);
      else
        this.ClearVerificationState(documentPackage);
      
      // Вызываем асинхронную выдачу прав, так как убрали ее при сохранении.
      this.EnqueueGrantAccessRightsJobs(documentPackage);

      this.FinalizeProcessing(blobPackage);
    }
    
    /// <summary>
    /// Обработать документы в Ario при необходимости.
    /// </summary>
    /// <param name="box">Абонентский ящик.</param>
    /// <param name="documents">Документы.</param>
    /// <param name="serviceMessageId">Id сообщения.</param>
    [Public]
    public virtual void ProcessToArioIfNecessary(Sungero.ExchangeCore.IBoxBase box, List<Sungero.Docflow.IOfficialDocument> documents)
    {
      var exchangeDocs = documents.Where(doc => Sungero.Docflow.ExchangeDocuments.Is(doc)).ToList();
      var incomingInvoice = documents.Where(doc => Sungero.Contracts.IncomingInvoices.Is(doc)).ToList();
      exchangeDocs.AddRange(incomingInvoice);
      
      var nonfDocsIds = string.Join(", ", exchangeDocs.Select(doc => doc.Id));

      Logger.DebugFormat("ProcessToArioIfNecessary. Старт обработки сообщения системы обмена: абонентский ящик: {0}, ИД документов: {1}",
                         box.Name, nonfDocsIds);
      
      // Неформализованные документы отправляем на обработку в Арио.
      if (exchangeDocs.Any() )
        this.ElectronicToArio(exchangeDocs);

      
      Logger.DebugFormat("ProcessToArioIfNecessary. Завершена обработка сообщения системы обмена.");
    }
    
    /// <summary>
    /// Заполнение карточек документов через арио, без пересоздания тел документов.
    /// </summary>
    /// <param name="docs">Документы типа ExchangeDocument.</param>
    /// <returns>Текст ошибки в случае её появления</returns>
    [Public]
    public virtual string ElectronicToArio(List<Sungero.Docflow.IOfficialDocument> docs)
    {
      var result = string.Empty;
      
      if (docs == null)
      {
        result = "ElectronicToArio: an empty list submitted to input";
        Logger.Error(result);
        return result;
      }

      var exchangeServiceName = string.Empty;
      var counterpartyName = string.Empty;
      var boxName = string.Empty;
      var incomeDate = Calendar.Now.ToString();
      
      var firstDoc = docs.FirstOrDefault();
      var exDocumentInfo = Sungero.Exchange.ExchangeDocumentInfos.GetAll(i => Sungero.Docflow.OfficialDocuments.Equals(i, firstDoc)).FirstOrDefault();
      if (exDocumentInfo != null)
      {
        exchangeServiceName = exDocumentInfo.RootBox.ExchangeService.Name;
        counterpartyName = exDocumentInfo.Counterparty.Name;
        boxName = exDocumentInfo.Box.Name;
      }
      
      var blobPackage = Sungero.SmartProcessing.BlobPackages.Create();
      blobPackage.PackageId = Guid.NewGuid().ToString();
      blobPackage.SourceName = PublicConstants.Module.ElectronicLineText;
      blobPackage.SenderLine = PublicConstants.Module.ElectronicLineText;
      
      foreach (var doc in docs.Where(d => d.HasVersions == true))
      {
        var newBlob = NonformalDocSmartProcessing.Blobs.Create();
        newBlob.ExistingDocIdDirRX  = doc.Id;
        var lVer = doc.LastVersion;
        newBlob.OriginalFileName = doc.Id.ToString() + "." + lVer.AssociatedApplication.Extension;
        newBlob.FilePath = "Original." + lVer.AssociatedApplication.Extension;
        using (var ms = new System.IO.MemoryStream())
        {
          doc.LastVersion.Body.Read().CopyTo(ms);
          newBlob.Body.Write(ms);
        }
        newBlob.PageCount = 0;
        newBlob.Name = doc.Name;
        newBlob.Save();
        blobPackage.Blobs.AddNew().Blob = newBlob;
      }
      blobPackage.Save();
      
      if (!blobPackage.Blobs.Any())
        return result;
      
      try
      {
        this.ProcessPackageInArioS(blobPackage);
        
        this.ProcessCapturedPackage(blobPackage);
      }
      catch (Exception ex)
      {
        Logger.ErrorFormat(string.Format("«{0}».{1} StackTrace: {2}", ex.Message, Environment.NewLine, ex.StackTrace));
        throw;
      }
      
      return result;
    }
    
    /// <summary>
    /// Обработать в Ario пакет бинарных образов документов.
    /// </summary>
    /// <param name="blobPackage">Пакет бинарных образов документов.</param>
    [Public]
    public virtual void ProcessPackageInArioS(Sungero.SmartProcessing.IBlobPackage blobPackage)
    {
      // Получение настроек.
      var smartProcessingSettings = Sungero.Docflow.SmartProcessingSettings.GetAllCached().SingleOrDefault();
      var firstPageClassifierId = smartProcessingSettings.FirstPageClassifierId.ToString();
      var typeClassifierId = smartProcessingSettings.TypeClassifierId.ToString();
      this.LogMessage(string.Format("ProcessPackageInArioS: First page classifier: name - \"{0}\", id - {1}.",
                                    smartProcessingSettings.FirstPageClassifierName, firstPageClassifierId), blobPackage);
      this.LogMessage(string.Format("ProcessPackageInArioS: Type classifier: name - \"{0}\", id - {1}.",
                                    smartProcessingSettings.TypeClassifierName, typeClassifierId), blobPackage);
      
      // Получить соответствие класса и наименования правила извлечения фактов.
      var processingRule = smartProcessingSettings.ProcessingRules
        .Where(x => !string.IsNullOrWhiteSpace(x.ClassName) && !string.IsNullOrWhiteSpace(x.GrammarName)).ToLookup(x => x.ClassName, x => x.GrammarName)
        .ToDictionary(x => x.Key, x => x.First());
      // Получение доп. классификаторов.
      var additionalClassifierIds = Sungero.Docflow.PublicFunctions.SmartProcessingSetting.GetAdditionalClassifierIds(smartProcessingSettings);
      
      // Получение языков распознавания.
      var supportedLanguagesString = smartProcessingSettings.Languages;
      var supportedLanguages = new List<string>();
      if (!string.IsNullOrEmpty(supportedLanguagesString))
      {
        supportedLanguages = supportedLanguagesString.Trim().Split(';').Select(s => s.Trim())
          .Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
      }
      
      // Обработка в Ario.
      var arioConnector = this.GetArioConnector();
      var blobs = blobPackage.Blobs.Select(x => x.Blob).Where(b => Sungero.SmartProcessing.Blobs.As(b).ArioTaskStatus != Sungero.SmartProcessing.Blob.ArioTaskStatus.Success);
      foreach (var blobSol in blobs)
      {
        var blob = Sungero.SmartProcessing.Blobs.As(blobSol);
        var fileName = blob.OriginalFileName;
        var filePath = blob.FilePath;

        var sizeInfo = blob.PageCount != 0 ? "pages: " + blob.PageCount.ToString() + " size: " + blob.Body.Size.ToString() + "B" : "pages: " + blob.PageCount.ToString();
        this.LogMessage(string.Format("ProcessPackageInArioS: File: {0}, {1}", fileName, sizeInfo), blobPackage);
        
        if (!Sungero.ArioExtensions.ArioConnector.CanArioProcessFile(filePath))
        {
          this.LogMessage(string.Format("ProcessPackageInArioS: File extension is not supported by Ario; {0} will be uploaded as a simple document.", fileName), blobPackage);
          continue;
        }
        
        try
        {
          var docBody = new byte[0];
          using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
          {
            blob.Body.Read().CopyTo(ms);
            docBody = ms.ToArray();
          }
          
          var dBegin = Calendar.Now;
          var arioExtractResult = new Sungero.ArioExtensions.Models.ExtractionResults();
          var arioResultJson = string.Empty;

          this.LogMessage(string.Format("ProcessPackageInArioS: Begin classification and facts extraction. File: {0}", fileName), blobPackage);
          
          var options = new List<KeyValuePair<string, string>>();
          if (additionalClassifierIds.Any())
            options.Add(Sungero.ArioExtensions.ArioConnector.CreateRequestParameter(Sungero.ArioExtensions.ArioConnector.AdditionalClassifierIdsParameterName, additionalClassifierIds));
          if (supportedLanguages.Any())
            options.Add(Sungero.ArioExtensions.ArioConnector.CreateRequestParameter(Sungero.ArioExtensions.ArioConnector.LanguagesParameterName, supportedLanguages));

          
          arioResultJson = arioConnector.ClassifyAndExtractFacts(docBody,
                                                                 fileName,
                                                                 typeClassifierId,
                                                                 firstPageClassifierId,
                                                                 processingRule,
                                                                 options.ToArray());
          blob.ArioResultJson = arioResultJson;
          this.LogMessage(string.Format("ProcessPackageInArioS: End classification and facts extraction. File: {0}, processed: {1}", fileName, (Calendar.Now - dBegin).ToString()), blobPackage);

          blob.Save();
        }
        catch (Exception ex)
        {
          this.LogMessage(string.Format("ProcessPackageInArioS: An error has occurred during classification and facts extraction. File: {0} errortext: {1}", fileName, ex), blobPackage);
          throw ex;
        }
      }
    }
    
    /// <summary>
    /// Получить коннектор к Ario.
    /// </summary>
    /// <returns>Коннектор к Ario.</returns>
    /// <remarks> Функция по получению коннектора к Арио уже есть в Docflow,
    /// но ее нельзя использовать здесь, так как возвращаемый тип - Sungero.ArioExtensions.ArioConnector,
    /// а сторонние библиотеки не могут быть в качестве возвращаемого результата Public/Remote функций (ограничение платформы).
    /// Поэтому приходится дублировать функцию GetArioConnector в модуле SmartProcessing.</remarks>
    public virtual Sungero.ArioExtensions.ArioConnector GetArioConnector()
    {
      var timeoutInSeconds = Sungero.Docflow.PublicFunctions.SmartProcessingSetting.Remote.GetArioConnectionTimeoutInSeconds();
      var timeout = new TimeSpan(0, 0, timeoutInSeconds);
      var smartProcessingSettings = Sungero.Docflow.PublicFunctions.SmartProcessingSetting.GetSettings();
      var password = string.IsNullOrEmpty(smartProcessingSettings.Password)
        ? string.Empty
        : Encryption.Decrypt(smartProcessingSettings.Password);
      return Sungero.ArioExtensions.ArioConnector.Get(smartProcessingSettings.ArioUrl, timeout, smartProcessingSettings.Login, password);
    }
    
    
  }
}