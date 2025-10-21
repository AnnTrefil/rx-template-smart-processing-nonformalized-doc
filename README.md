# rx-template-smart-processing-nonformalized-doc
Репозиторий с шаблоном разработки «Распознавание неформализованных документов электронного обмена».

## Описание
Решение позволяет:
Добавлять блок типа скрипт «Распознавание неформализованных документов электронного обмена», с помощью которого неформализованные документы, поступившие из сервиса электронного обмена Диадок, будут автоматически интеллектуально обрабатываться сервисами Ario.

Состав объектов разработки:
1.	Перекрытие модуля «Интеллектуальная обработка» (SmartProcessing).
2.	Блок типа Скрипт «Распознавание неформализованных документов эл. обмена.»
3.	Перекрытие справочника «Бинарные образы документов» (Blob). 
4.	Заказное свойство ExistingDocId в перекрытии справочника «Бинарные образы документов» (Blob). 
5.	Константа ElectronicLineText.
6.	Переопределенные функции: CreateSupAgreement, CreateWaybill, CreateUniversalTransferDocument, CreateUniversalTransferCorrectionDocument, CreateTaxInvoice, CreateTaxInvoiceCorrection, CreateSimpleDocument, CreateIncomingLetter, CreateIncomingInvoice, CreateContractStatement, CreateContract.
7.	Функции:	ProcessToArio, FillingDocumentCardsInArio, ProcessPackageInArioS.
8.	Копии функций базового слоя: ProcessCapturedPackage, GetArioConnector.


> [!NOTE]
> Замечания и пожеланию по развитию шаблона разработки фиксируйте через [Issues](https://github.com/DirectumCompany/<имя репозитория>/issues).
При оформлении ошибки, опишите сценарий для воспроизведения. Для пожеланий приведите обоснование для описываемых изменений - частоту использования, бизнес-ценность, риски и/или эффект от реализации.
> 
> Внимание! Изменения будут вноситься только в новые версии.

## Варианты расширения функциональности на проектах
1.	Использовать блок в любых задачах. Добавить обработку на событии «Выполнение» блока Скрипт «Распознавание неформализованных документов эл. обмена.»
2.	Изменить логику создания документов после обработки в переопределениях функций CreateSupAgreement, CreateWaybill, CreateUniversalTransferDocument, CreateUniversalTransferCorrectionDocument, CreateTaxInvoice, CreateTaxInvoiceCorrection, CreateSimpleDocument, CreateIncomingLetter, CreateIncomingInvoice, CreateContractStatement, CreateContract.
3.	Изменить логику отправки на верификатора в функции ProcessCapturedPackage.

## Порядок установки
Для работы требуется установленный Directum RX версии 4.12 и выше.

## Установка для ознакомления
1. Склонировать репозиторий с rx-template-smart-processing-nonformalized-doc в папку.
2. Указать в _ConfigSettings.xml DDS:
```xml
<block name="REPOSITORIES">
  <repository folderName="Base" solutionType="Base" url="" /> 
  <repository folderName="<Папка из п.1>" solutionType="Work" 
     url="https://github.com/DirectumCompany/rx-template-smart-processing-nonformalized-doc" />
</block>
```

## Установка для использования на проекте
Возможные варианты

**A. Fork репозитория**
1. Сделать fork репозитория rx-template-smart-processing-nonformalized-doc для своей учетной записи.
2. Склонировать созданный в п. 1 репозиторий в папку.
3. Указать в _ConfigSettings.xml DDS:
```xml
<block name="REPOSITORIES">
  <repository folderName="Base" solutionType="Base" url="" /> 
  <repository folderName="<Папка из п.2>" solutionType="Work" 
     url="https://github.com/DirectumCompany/rx-template-smart-processing-nonformalized-doc" />
</block>
```

**B. Подключение на базовый слой.**
Вариант не рекомендуется, так как при выходе версии шаблона разработки не гарантируется обратная совместимость.
1. Склонировать репозиторий rx-template-smart-processing-nonformalized-doc в папку.
2. Указать в _ConfigSettings.xml DDS:
```xml
<block name="REPOSITORIES">
  <repository folderName="Base" solutionType="Base" url="" /> 
  <repository folderName="<Папка из п.1>" solutionType="Base" 
     url="<Адрес репозитория gitHub>" />
  <repository folderName="<Папка для рабочего слоя>" solutionType="Work" 
     url="<Адрес репозитория для рабочего слоя>" />
</block>
```

**C. Копирование репозитория в систему контроля версий.**
Рекомендуемый вариант для проектов внедрения.
1. В системе контроля версий с поддержкой git создать новый репозиторий.
2. Склонировать репозиторий <Название репозитория> в папку с ключом `--mirror`.
3. Перейти в папку из п. 2.
4. Импортировать клонированный репозиторий в систему контроля версий командой:
`git push –mirror <Адрес репозитория из п. 1>`

