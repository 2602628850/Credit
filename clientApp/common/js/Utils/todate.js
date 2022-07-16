//将毫秒的时间转换成美式英语的时间格式,eg:3rd May 2018
function formatDate(millinSeconds) {
	var date = new Date(millinSeconds);
	var monthArr = new Array("Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Spt", "Oct", "Nov",
		"Dec");
	var suffix = new Array("st", "nd", "rd", "th");

	var year = date.getFullYear(); //年
	var month = monthArr[date.getMonth()]; //月
	var ddate = date.getDate(); //日

	if (ddate % 10 < 1 || ddate % 10 > 3) {
		ddate = ddate + suffix[3];
	} else if (ddate % 10 == 1) {
		ddate = ddate + suffix[0];
	} else if (ddate % 10 == 2) {
		ddate = ddate + suffix[1];
	} else {
		ddate = ddate + suffix[2];
	}
	var dt = date.getHours() + " : " + date.getMinutes();
	return ddate + " " + month + " " + year + " " + dt;
}
function formatDateCh(millinSeconds) {
	var date = new Date(millinSeconds);
	var year = date.getFullYear(); //年
	var month = date.getMonth(); //月
	var ddate = date.getDate(); //日
	var sh = date.getHours(); //时
	var mi = date.getMinutes();
	return year + "-" + month + " " + ddate + " " + sh + ":" + mi;
}
export {
    formatDate,
    formatDateCh
}
