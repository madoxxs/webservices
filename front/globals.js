userInfo = {
	sessionId: "",
	userId: "",
	userName:"",
	firstName:"",
	lastName:"",
	address:"",
	email:""
}

var auro = {};

var path="pages/"; 
var servicePart="http://192.168.43.28/simeoneService/api/",
    
	base64Code = "";
	
var translate = {
	FullName: "Имена",
	EGN: "ЕГН",
	Address:"Адрес",
	UserId:"Персонален номер",
	MobilePhone:"Мобилен номер",
	Email:"Имейл",
	Company:"Застрахователна компания",
	DocumentNumber:"Прилагам документ номер",
	IBAN:"Банкова сметка IBAN",
	AttachFile:"Прикачен амбулаторен лист",
	Area:"Разгърната площ на имота",
	InsuranceAmount:"Застрахователна сума",
	Kind:"Вид на имуществото",
	OwnerFullName:"Име на застрахования притежател",
	OwnerAddress:"Адрес на застрахования притевател",
	OwnerPhone:"Телефон на застрахования притежател",
	MPSModel:"Модел и марка на МПС",
	MPSNumber:"Номер на МПС",
	TrailerNumber:"Номер на ремарке",
	InsurerCompany:"Застрахователна компания",
	InsurerPolicyNumber:"Застрахователна полица номер",
	InsurerGreenCardNumber:"Зелена карта номер",
	ValidFrom:"Застрахователна полица валидна от",
	ValidTo:"Застрахователна полица валидна до",
	InsurerAgency:"Агенция или брокер",
	InsurerAddress:"Адрес",
	InsurerPhone:"Телефон",
	LeaderFullName:"Име и фамилия на водача",
	LeaderBornDate:"Дата на раждане",
	LeaderAddress:"Адрес на водача",
	LeaderPhone:"Телефонен номер на водача",
	LeaderCertificate:"Свидетелство номер",
	LeaderCategory:"Категория",
	LeaderCertificateValidTo:"Валидност на свидетелство",
	PolicyNumber:"Полица номер",
	VisibleDamage:"Видими щети"
};
