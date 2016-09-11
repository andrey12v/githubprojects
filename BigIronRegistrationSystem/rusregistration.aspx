<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="rusregistration.aspx.cs" Inherits="Default2" Title="Big Iron Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainPlaceholder" Runat="Server">
    <span style="font-size: 10pt">
        Rus | <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/englregistration.aspx">Engl</asp:HyperLink></span><br />
    <br />
    <strong><span style="font-size: 11pt">
    Регистрация на выставку "Биг Айрон"</span></strong><br/>
    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label><br />
    <span><span style="font-size: 10pt"><span>
        <br />
        Имя:</span> </span>
        <asp:TextBox ID="txtFirstName" runat="server" Width="203px"></asp:TextBox><span style="font-size: 10pt">
            Фамилия<span>:</span></span><asp:TextBox ID="txtLastName" runat="server" Width="243px"></asp:TextBox>&nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName"
            ErrorMessage="нет имени"></asp:RequiredFieldValidator>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName"
            ErrorMessage="нет фамилии"></asp:RequiredFieldValidator><br />
    </span><span style="font-size: 10pt">Должность: &nbsp;</span><asp:TextBox ID="txtJobTitle" runat="server" Width="164px"></asp:TextBox><span
        style="font-size: 10pt">&nbsp; Организация:&nbsp; </span>
    <asp:TextBox ID="txtCompany" runat="server" Width="202px"></asp:TextBox><br />
    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtJobTitle"
            ErrorMessage="нет названия должности"></asp:RequiredFieldValidator>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtCompany"
            ErrorMessage="нет названия организации"></asp:RequiredFieldValidator><br />
        Адрес:&nbsp; </span>
    <asp:TextBox ID="txtAddress" runat="server" Width="494px"></asp:TextBox><br />
    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtAddress"
            ErrorMessage="нет адреса"></asp:RequiredFieldValidator><br />
        Город:&nbsp; </span>
    <asp:TextBox ID="txtCity" runat="server" Width="187px"></asp:TextBox><span style="font-size: 10pt">&nbsp; Округ/Область:&nbsp; </span>
    <asp:TextBox ID="txtState" runat="server" Width="196px"></asp:TextBox><br />
    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCity"
            ErrorMessage="нет названия города"></asp:RequiredFieldValidator>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <br />
        Страна:&nbsp; </span>
    <asp:TextBox ID="txtCountry" runat="server" Width="198px"></asp:TextBox><span style="font-size: 10pt">&nbsp; &nbsp;Почтовый индекс:&nbsp; </span>
    <asp:TextBox ID="txtPostalCode" runat="server" Width="157px"></asp:TextBox><br />
    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCountry"
            ErrorMessage="нет страны"></asp:RequiredFieldValidator>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtPostalCode"
            ErrorMessage="нет почтового индекса"></asp:RequiredFieldValidator><br />
    Email:&nbsp; </span>
    <asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox><span style="font-size: 10pt">&nbsp; Веб сайт:&nbsp; </span>
    <asp:TextBox ID="txtWebSite" runat="server" Width="218px"></asp:TextBox><br />
    <span style="font-size: 10pt">&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmail"
            ErrorMessage="нет электронной почты"></asp:RequiredFieldValidator>&nbsp;
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
            ErrorMessage="неправильный адрес электронной почты" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator><br />
        Телефон: &nbsp;</span><asp:TextBox ID="txtPhone" runat="server" Width="194px"></asp:TextBox><span
        style="font-size: 10pt">&nbsp; Факс:&nbsp; </span>
    <asp:TextBox ID="txtFax" runat="server" Width="227px"></asp:TextBox><br />
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPhone"
        ErrorMessage="нет номера телефона"></asp:RequiredFieldValidator>&nbsp;
    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtPhone"
        ErrorMessage="неправельный формат номера телефона" MaximumValue="9" MinimumValue="0"></asp:RangeValidator><br />
    <br />
    <strong>Интересуемая продукция:<br />
    </strong>
    <p class="MsoNormal" style="margin: 0in 0in 0pt">
        <span style="font-size: 10pt">Пожалуйста, отметьте продукцию, которую бы вы хотели увидеть
            на выставке: </span>
    </p>
    <asp:CheckBoxList ID="cblProductInterest" runat="server" RepeatColumns="2" ValidationGroup="0" Font-Size="10pt">
        <asp:ListItem Value="1">Трактора</asp:ListItem>
        <asp:ListItem Value="2">Сеялки</asp:ListItem>
        <asp:ListItem Value="3">Грузовики/Прицепы</asp:ListItem>
        <asp:ListItem Value="4">Семена/Химикаты/Удобрения/Пестициды</asp:ListItem>
        <asp:ListItem Value="5">Комбайны/Жатки</asp:ListItem>
        <asp:ListItem Value="6">Сеноуборочная техника</asp:ListItem>
        <asp:ListItem Value="7">Распылители/Оборудование по внесению удобрений</asp:ListItem>
        <asp:ListItem Value="8">Обработка материалов</asp:ListItem>
        <asp:ListItem Value="9">Обработка зерна (стандартные, винтовые конвейеры, емкости для  хранения, сушилки)</asp:ListItem>
        <asp:ListItem Value="10">Оборудование по обработке почвы</asp:ListItem>
    </asp:CheckBoxList><span style="font-size: 10pt"> &nbsp;&nbsp; Другое:</span><span style="font-size: 10pt">&nbsp; </span>
    <asp:TextBox ID="txtProdInterest" runat="server" Width="487px"></asp:TextBox><span><span
        style="font-size: 10pt"> &nbsp;
    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
        <br />
    </span>
        <p class="MsoNormal" style="margin: 0in 0in 0pt">
        </p>
            <span style="font-size: 10pt"><strong>Статус посетителя:</strong><br />
                <span style="mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: RU; mso-fareast-language: RU;
                    mso-bidi-language: AR-SA">Пожалуйста, отметьте варианты, которые характеризуют ваш
                    вид деятельности</span></span>&nbsp;<br />
        <asp:CheckBoxList ID="cblVisitorStatus" runat="server" RepeatColumns="2" Font-Size="10pt">
        <asp:ListItem Value="1">Дистрибьютор/Оптовый поставщик</asp:ListItem>
        <asp:ListItem Value="2">Представитель предприятия/Торговый агент</asp:ListItem>
        <asp:ListItem Value="3">Заведующий сельским хозяйством </asp:ListItem>
        <asp:ListItem Value="4">Представитель оборудования</asp:ListItem>
        <asp:ListItem Value="5">Производитель</asp:ListItem>
        <asp:ListItem Value="6">Организация по импорту/экспорту</asp:ListItem>
        <asp:ListItem Value="7">Сельскохозяйственное объединение</asp:ListItem>
    </asp:CheckBoxList></span><span style="font-size: 10pt"><span>&nbsp; Другое:&nbsp;</span><span> </span>
        </span>
    <asp:TextBox ID="txtVisitorStatus" runat="server" Width="487px"></asp:TextBox><br />
    <br />
    <span><span>
        <p class="MsoNormal" style="margin: 0in 0in 0pt">
            <b><span style="font-size: 10pt">Цель визита:<?xml namespace="" ns="urn:schemas-microsoft-com:office:office"
                prefix="o" ?><o:p></o:p></span></b></p>
        <span style="font-size: 10pt"><span style="mso-fareast-font-family: 'Times New Roman';
            mso-ansi-language: RU; mso-fareast-language: RU; mso-bidi-language: AR-SA">Пожалуйста,
            отметьте варианты, которые объясняют цель вашего визита на выставку "Биг Айрон":</span><br />
        </span>
    </span>
    </span>
    <asp:CheckBoxList ID="cblPurposeVisit" runat="server" RepeatColumns="1" Font-Size="10pt">
        <asp:ListItem Value="1">Покупка/ Размещение заказов</asp:ListItem>
        <asp:ListItem Value="2">Сбор информации</asp:ListItem>
        <asp:ListItem Value="3">Рассмотрение выставки с целью дальнейшего участия</asp:ListItem>
        <asp:ListItem Value="4">Поиск новых поставщиков оборудования/ Товаров</asp:ListItem>
        <asp:ListItem Value="5">Встреча с существующими поставщиками/ Деловыми партнерами</asp:ListItem>
    </asp:CheckBoxList><span style="font-size: 10pt"><span>&nbsp; Другое:</span><span> &nbsp; </span></span><asp:TextBox ID="txtPurposeVisit" runat="server" Width="487px"></asp:TextBox><br />
    <br />
    <span><span>
        <p class="MsoNormal" style="margin: 0in 0in 0pt">
            <span style="font-size: 10pt"><strong>Сельскохозяйственные культуры:</strong></span></p>
        <p class="MsoNormal" style="margin: 0in 0in 0pt">
            <span style="font-size: 10pt">Пожалуйста, выберите основные сельскохозяйственные культуры,
                которые вы или ваши клиенты производят: </span>
        </p>
    </span>
    </span>
    <asp:CheckBoxList ID="cblCropInterest" runat="server" RepeatColumns="3" Font-Size="10pt">
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
    </asp:CheckBoxList><span style="font-size: 10pt"><span> &nbsp;&nbsp;Другое:</span><span> </span>
    </span>
    <asp:TextBox ID="txtCropInterest" runat="server" Width="487px"></asp:TextBox><br />
    <span style="font-size: 10pt">
        <br />
        Вам нужен переводчик? </span>
    <asp:RadioButtonList ID="rblInterpreter" runat="server" RepeatColumns="2" Font-Size="9pt">
       <asp:ListItem Value="1" Selected="True">Да</asp:ListItem>
        <asp:ListItem Value="0">Нет</asp:ListItem>
    </asp:RadioButtonList><span style="font-size: 10pt">Если да, то какой язык?&nbsp; &nbsp;</span><asp:TextBox
        ID="txtLanguage" runat="server" Width="272px"></asp:TextBox><br />
    <br />
    <span><span style="font-size: 10pt">
    <span>Пожалуйста<span style="mso-fareast-font-family: 'Times New Roman';
        mso-ansi-language: RU; mso-fareast-language: RU; mso-bidi-language: AR-SA">, сохраните
        ваши данные и, если необходимо, распечатайте форму.</span><br />
    </span>
    <br />
    &nbsp; </span></span>
    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Сохранить" ></asp:Button>
    &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; <input id="Button1" type="button"
        value="Распечатать пустой бланк "  onclick="window.open('rusprintform.aspx?id=blank', '_blank');" />
    <span style="font-size: 10pt"> &nbsp; &nbsp;&nbsp; 
        <br />
        <br />
        &nbsp;
         <asp:Literal ID="btnLiteral" runat="server"></asp:Literal><br />
</asp:Content>

