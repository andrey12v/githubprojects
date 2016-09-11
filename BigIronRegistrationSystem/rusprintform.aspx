<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rusprintform.aspx.cs" Inherits="rusprintform" %>

<html lang="ru" >
<head runat="server">
<meta http-equiv="content-type" content="text/html;charset=utf-8" />
    <title></title>
</head>
<body>

<script type="text/javascript">
<!--
window.print();

//-->
</script>

    <form id="form1" runat="server">
    <div style="text-align: center"><center>
        <asp:Image ID="Image1" runat="server" Height="86px" ImageUrl="~/images/bigiron.JPG"
            Width="411px" /><br />
        <span style="font-size: 12pt">
            <p class="MsoNormal" style="margin: 0in 0in 0pt">
                <span style="font-size: 11pt"><strong>Регистрационная
                    форма на программу для международных посетителей, выставки "Биг Айрон"</strong></span></p>
        </span>
        <table style="font-size: 10pt; width: 774px">
            <tr>
                <td style="width: 64px; text-align: left">
                    Имя:</td>
                <td style="width: 278px; border-bottom: black 1px solid; text-align: left">
                    <asp:Label ID="lblFirstName" runat="server"></asp:Label><span style="font-size: 1pt">.</span></td>
                <td style="width: 104px; text-align: left">
                    Фaмилия:</td>
                <td style="border-bottom: black 1px solid; text-align: left; width: 277px;">
                    <asp:Label ID="lblLastName" runat="server"></asp:Label><span style="font-size: 1pt">.</span></td>
            </tr>
            <tr>
                <td style="width: 64px; text-align: left; height: 18px;">
                    Должность:</td>
                <td style="width: 278px; border-bottom: black 1px solid; text-align: left; height: 18px;">
                    <asp:Label ID="lblJobTitle" runat="server"></asp:Label><span style="font-size: 1pt">.</span></td>
                <td style="width: 104px; text-align: left; height: 18px;">
                    Организация:</td>
                <td style="border-bottom: black 1px solid; text-align: left; width: 277px; height: 18px;">
                    <asp:Label ID="lblCompany" runat="server"></asp:Label><span style="font-size: 1pt">.</span></td>
            </tr>
            <tr>
                <td style="width: 64px; text-align: left">
                    Адрес:</td>
                <td colspan="3" style="border-bottom: black 1px solid; text-align: left">
                    <asp:Label ID="lblAddress" runat="server"></asp:Label><span style="font-size: 1pt">.</span></td>
            </tr>
            <tr>
                <td style="width: 64px; text-align: left">
                    Город:</td>
                <td style="width: 278px; border-bottom: black 1px solid; text-align: left">
                    <asp:Label ID="lblCity" runat="server" Font-Bold="False"></asp:Label><span style="font-size: 1pt">.</span></td>
                <td style="width: 104px; text-align: left">
                    Округ/Область:</td>
                <td style="width: 277px; border-bottom: black 1px solid; text-align: left">
                    <asp:Label ID="lblState" runat="server" Font-Bold="False"></asp:Label><span style="font-size: 1pt">.</span></td>
            </tr>
            <tr>
                <td style="width: 64px; text-align: left">
                    Страна:</td>
                <td style="font-weight: width: 302px; border-bottom: black 1px solid;
                    text-align: left; width: 278px;">
                    <asp:Label ID="lblCountry" runat="server" Font-Bold="False"></asp:Label><span style="font-size: 1pt">.</span></td>
                <td style="width: 104px; text-align: left">
                    Почтовый индекс:</td>
                <td style="width: 277px; border-bottom: black 1px solid; text-align: left">
                    <asp:Label ID="lblPostalCode" runat="server"></asp:Label><span style="font-size: 1pt">.</span></td>
            </tr>
            <tr>
                <td style="width: 64px; text-align: left">
                    Email:</td>
                <td style="font-weight: bold; width: 278px; border-bottom: black 1px solid;
                    text-align: left">
                    <asp:Label ID="lblEmail" runat="server" Font-Bold="False"></asp:Label><span style="font-size: 1pt">.</span></td>
                <td style="width: 104px; text-align: left">
                    Веб сайт:</td>
                <td style="width: 277px; border-bottom: black 1px solid; text-align: left">
                    <asp:Label ID="lblWebSite" runat="server"></asp:Label><span style="font-size: 1pt">.</span></td>
            </tr>
            <tr>
                <td style="width: 64px; text-align: left">
                    Телефон:</td>
                <td style="width: 278px; border-bottom: black 1px solid;
                    text-align: left">
                    <asp:Label ID="lblPhone" runat="server" Font-Bold="False"></asp:Label><span style="font-size: 1pt">.</span></td>
                <td style="width: 104px; text-align: left">
                    Факс:</td>
                <td style="width: 277px; border-bottom: black 1px solid; text-align: left">
                    <asp:Label ID="lblFax" runat="server"></asp:Label><span style="font-size: 1pt">.</span></td>
            </tr>
        </table>
        <table style="font-size: 10pt; font-family: Times New Roman;">
            <tr>
                <td colspan="3" style="width: 762px; text-align: left;">
                    <span><strong>Интересуемая продукция:<br />
                    </strong>
                    </span>Пожалуйста, отметьте продукцию, которую бы вы хотели увидеть на
                    выставке:
                </td>
            </tr>
            <tr>
                <td colspan="3" style="width: 762px; text-align: left; border-bottom: black 1px solid;">
                    <asp:CheckBoxList ID="cblProductInterest" runat="server" EnableTheming="True" Font-Size="10pt"
                        ForeColor="Black" RepeatColumns="2" ValidationGroup="0" Width="768px">
                        <asp:ListItem Value="1">Трактора</asp:ListItem>
                        <asp:ListItem Value="2">Сеялки</asp:ListItem>
                        <asp:ListItem Value="3">Грузовики/Прицепы</asp:ListItem>
                        <asp:ListItem Value="4">Семена/ Химикаты/ Удобрения/ Пестициды</asp:ListItem>
                        <asp:ListItem Value="5">Комбайны/Жатки</asp:ListItem>
                        <asp:ListItem Value="6">Сеноуборочная техника</asp:ListItem>
                        <asp:ListItem Value="7">Распылители/Оборудование по внесению удобрений</asp:ListItem>
                        <asp:ListItem Value="8">Обработка материалов</asp:ListItem>
                        <asp:ListItem Value="9">Обработка зерна (стандартные, винтовые конвейеры, емкости для  хранения, сушилки)</asp:ListItem>
                        <asp:ListItem Value="10">Оборудование по обработке почвы</asp:ListItem>
                    </asp:CheckBoxList>&nbsp;<asp:CheckBox ID="cbOtherProductInterest" runat="server"
                        Text="Другое:" />&nbsp;
                    <asp:Label ID="lblOtherProductInterest" runat="server" Font-Underline="False"></asp:Label>&nbsp;
                </td>
            </tr>
        </table>
        <table style="font-size: 10pt; font-family: Times New Roman;">
            <tr>
                <td style="width: 771px; text-align: left">
                    <span>
                        <p class="MsoNormal" style="margin: 0in 0in 0pt">
                            <strong>Статус посетителя:<br />
                            </strong>Пожалуйста, отметьте пункты, которые характеризуют ваш вид деятельности
                        </p>
                    </span></td>
            </tr>
            <tr>
                <td style="width: 771px; text-align: left; border-bottom: black 1px solid;">
                    <asp:CheckBoxList ID="cblVisitorStatus" runat="server" Font-Size="10pt" RepeatColumns="3">
                        <asp:ListItem Value="1">Дистрибьютор/ Оптовый поставщик</asp:ListItem>
                        <asp:ListItem Value="2">Представитель предприятия/ Торговый агент</asp:ListItem>
                        <asp:ListItem Value="3">Заведующий сельским хозяйством</asp:ListItem>
                        <asp:ListItem Value="4">Представитель оборудования</asp:ListItem>
                        <asp:ListItem Value="5">Производитель</asp:ListItem>
                        <asp:ListItem Value="6">Организация по импорту/ Экспорту</asp:ListItem>
                        <asp:ListItem Value="7">Сельскохозяйственное объединение</asp:ListItem>
                    </asp:CheckBoxList>&nbsp;<asp:CheckBox ID="cbOtherVisitorStatus" runat="server" Text="Другое:" />&nbsp;
                    <asp:Label ID="lblOtherVisitorStatus" runat="server" Font-Underline="False"></asp:Label></td>
            </tr>
        </table>
        <table style="font-size: 10pt; font-family: Times New Roman;">
            <tr>
                <td style="width: 771px; text-align: left">
                    <span><strong><span style="font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: RU; mso-fareast-language: RU; mso-bidi-language: AR-SA">Цель
                        визита</span>:</strong><br />
                    </span><span style="font-family: 'Times New Roman'; mso-fareast-font-family: 'Times New Roman';
                        mso-ansi-language: RU; mso-fareast-language: RU; mso-bidi-language: AR-SA">Пожалуйста,
                        отметьте пункты, которые объясняют цель вашего визита на выставку "Биг Айрон":</span></td>
            </tr>
            <tr>
                <td style="width: 771px; text-align: left; border-bottom: black 1px solid;">
                    <asp:CheckBoxList ID="cblPurposeVisit" runat="server" Font-Size="10pt" RepeatColumns="2">
                        <asp:ListItem Value="1">Покупка/ Размещение заказов</asp:ListItem>
                        <asp:ListItem Value="2">Сбор информации</asp:ListItem>
                        <asp:ListItem Value="3">Рассмотрение выставки с целью дальнейшего участия</asp:ListItem>
                        <asp:ListItem Value="4">Поиск новых поставщиков оборудования/ Товаров</asp:ListItem>
                        <asp:ListItem Value="5">Встреча с существующими поставщиками/ Деловыми партнерами</asp:ListItem>
                    </asp:CheckBoxList>&nbsp;<asp:CheckBox ID="cbOtherPurposeVisit" runat="server" Text="Другое:" />&nbsp;
                    <asp:Label ID="lblOtherPurposeVisit" runat="server" Font-Underline="False"></asp:Label></td>
            </tr>
        </table>
        <table style="font-size: 10pt; font-family: Times New Roman;">
            <tr>
                <td style="width: 771px; text-align: left">
                    <span><strong>Сельскохозяйственные культуры:</strong><p class="MsoNormal" style="margin: 0in 0in 0pt">
                        Пожалуйста, выберите основные сельскохозяйственные культуры, которые вы или ваши
                        клиенты производят:</p>
                    </span></td>
            </tr>
            <tr>
                <td style="width: 771px; text-align: left; border-bottom: black 1px solid;">
                    <asp:CheckBoxList ID="cblCropInterest" runat="server" Font-Size="10pt" RepeatColumns="5">
                        <asp:ListItem Value="1">Ячмень</asp:ListItem>
                        <asp:ListItem Value="2">Картофель</asp:ListItem>
                        <asp:ListItem Value="3">Сахарная свекла</asp:ListItem>
                        <asp:ListItem Value="4">Канола</asp:ListItem>
                        <asp:ListItem Value="5">Соевые бобы</asp:ListItem>
                        <asp:ListItem Value="6">Озимая пшеница</asp:ListItem>
                        <asp:ListItem Value="7">Кукуруза</asp:ListItem>
                        <asp:ListItem Value="8">Яровая пшеница</asp:ListItem>
                        <asp:ListItem Value="9">Овес</asp:ListItem>
                        <asp:ListItem Value="10">Подсолнечники</asp:ListItem>
                    </asp:CheckBoxList>&nbsp;<asp:CheckBox ID="cbOtherCropInterest" runat="server" Text="Другое:" />&nbsp;
                    <asp:Label ID="lblOtherCropInterest" runat="server" Font-Underline="False"></asp:Label></td>
            </tr>
        </table>
        <table style="font-size: 10pt; font-family: Times New Roman;">
            <tr>
                <td style="width: 171px; height: 24px; text-align: left">
                    Вам нужен переводчик ?</td>
                <td style="width: 596px; height: 24px; text-align: left">
                    <asp:RadioButtonList ID="rblInterpreter" runat="server" RepeatColumns="2">
                        <asp:ListItem Value="1">Да</asp:ListItem>
                        <asp:ListItem Value="0">Нет</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            
            <tr>
            <td style="width: 171px; height: 18px">
                &nbsp; &nbsp;Если да, то какой язык ?&nbsp;
            </td>
            <td style="border-bottom: black 1px solid; width: 596px; height: 18px;"><asp:Label ID="lblLanguage" runat="server" Font-Underline="False"></asp:Label><span style="font-size: 1pt">.</span>
            </td>
            </tr>    
           </table> 
           <table> 
            
            <tr>    
                <td style="text-align: left; font-size: 10pt; width: 396px;">
                    По всем вопросам, пожалуйста, обращайтесь к<br />
                    Представителю Торгового Офиса на Украине<br />
                    <strong>Сергею Половенко</strong><br />
                    Телефон: &nbsp;&nbsp; +380503618644<br />
                    Эл. почта: &nbsp;sergiy@ndto.com<br />
                    Оболонский проспект 15/108,<br />
                    Киев, Украина 04205&nbsp;</td>
            <td style="font-size: 10pt; width: 372px;">
                    <strong>Торговый Офис штата Северная Дакота</strong><br />
                    Телефон: 701-235-3638<br />
                    Факс:&nbsp; &nbsp;&nbsp; &nbsp; &nbsp;701-235-0164<br />
                    112 Юниверсити Драйв, офис 260<br />
                    Фарго, штат Северная Дакота 58102    
            </td>
            </tr>
        </table>
        <asp:Image ID="Image2" runat="server" Height="43px" ImageUrl="~/images/logotradeoffice.JPG"
            Width="358px" /></center></div>
    </form>
</body>
</html>
