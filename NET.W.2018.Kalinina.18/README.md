# NET.W.2018.Kalinina.18
1. В текстовом файле построчно хранится информация о URL-адресах, представленных в виде <scheme>://<host>/<URL?path>?<parameters>, где сегмент parameters - это набор пар вида key=value, при этом сегменты URL?path и parameters  или сегмент parameters могут отсутствовать. 
Разработать систему типов (руководствоваться принципами SOLID) для экспорта данных, полученных на основе разбора информации текстового файла, в XML-документ по следующему правилу, например, для текстового файла с URL-адресами 
  
  https://github.com/AnzhelikaKravchuk?tab=repositories
  https://github.com/AnzhelikaKravchuk/2017-2018.MMF.BSU
  https://habrahabr.ru/company/it-grad/blog/341486/

  Результирующим является XML-документ вида (можно использовать любую XML технологию без ограничений).
  Для тех URL-адресов, которые не совпадают с данным паттерном, “залогировать” информацию, отметив указанные строки, как необработанные. 
 Продемонстрировать работу на примере консольного приложения.

5. Разработана система типов (проект No5) для описания документа - класс Document, состоящего из различного вида частей документа DocumentPart - BoldText, Hyperlink, PlainText (3 типа представлено только для краткости примера), части документа могут быть получены как часть API класса Document (если есть такая необходимость). Какие проблемы возникнут при использовании данного кода, если часто будет возникать необходимость добавления конвертирования документа в новый формат (например, обычный текст, html, LaTeX и т.д.)? Пересмотреть реализацию типов, устранив обнаруженную проблему (решение поместить в проект No5.Solution), проверить работу новой системы типов в консоли (проект No5.Solution.Console). Кратко описать предложенное решение.