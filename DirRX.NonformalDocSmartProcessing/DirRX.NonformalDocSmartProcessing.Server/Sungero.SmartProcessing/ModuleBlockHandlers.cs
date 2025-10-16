using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Sungero.Workflow;

namespace DirRX.NonformalDocSmartProcessing.Module.SmartProcessing.Server.SmartProcessingBlocks
{
  partial class SmartProcessNonformalDocDirRXHandlers
  {

    public virtual void SmartProcessNonformalDocDirRXExecute()
    {
      try
      {
        List<Sungero.Docflow.IOfficialDocument> documents = _obj.AllAttachments.Where(a => Sungero.Docflow.OfficialDocuments.Is(a))
          .Select(a => Sungero.Docflow.OfficialDocuments.As(a)).ToList();

        Logger.DebugFormat("SmartProcessNonformalDoc. ProcessToArioDirRXExecute. ID задачи: {0}. Обработка. Приложены следующие документы (ид): {1}.",
                           _obj.Id, string.Join(", ", documents.Select(d => d.Id)));
        
        var box = Sungero.Exchange.ExchangeDocumentProcessingTasks.Is(_obj) ? Sungero.Exchange.ExchangeDocumentProcessingTasks.As(_obj).Box : null;

        if (box == null)
        {
          Logger.DebugFormat("SmartProcessNonformalDoc. ProcessToArioDirRXExecute. ID задачи: {0}. box is null, stopping process.", _obj.Id);
          return;
        }

        Functions.Module.ProcessToArioIfNecessary(box, documents);
      }
      catch (Exception ex)
      {
        _block.RetrySettings.Retry = false;
        Logger.ErrorFormat("Ошибка при обработке в SmartProcessNonformalDocDirRXExecute. TaskId: {0}, Error: {1}{2}StackTrace: {3}",
                           _obj.Id, ex.Message, Environment.NewLine, ex.StackTrace);
        return;
        
      }
    }
  }

  partial class AnalyzeDocTypeAndFactsRecognitionBlockHandlers
  {

  }
}