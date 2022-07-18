import moment from "moment";

/**
 * 获取当前时间戳(UTC)
 * @returns {number}
 */
function nowUnix() {
    return moment(new Date()).utc().toDate().getTime();
}

/**
 * 获取传入时间戳
 * @param timeString
 */
function unix(timeString) {
    return moment(timeString).toDate().getTime();
}

function unixDayStart(timeString) {
    if (/^\d+$/g.test(timeString)) {
        return timeString;
    }
    return moment(timeString).startOf('day').toDate().getTime();
}

function unixDayEnd(timeString) {
    if (/^\d+$/g.test(timeString)) {
        return timeString;
    }
    return moment(timeString).endOf('day').toDate().getTime();
}

/**
 * 获取当日开始时间戳(UTC)
 * @returns {number}
 */
function beginOfDay() {
    return moment().startOf("day").utc().toDate().getTime();
}

/**
 * 获取传入时间 之前的时间戳
 * @param datetime  时间节点
 * @param day       {Number} 天
 */
function subtract(datetime, day) {
    return moment(datetime).subtract(day, "day").toDate().getTime();
}

/**
 * 格式化时间
 * @param dateTime    时间字符串
 * @param dateTimeFormat    时间字符串格式
 * @param format      转换后格式
 * @returns {string}
 */
function format(dateTime,dateTimeFormat, format = "YYYY-MM-DD HH:mm:ss") {
    let time = moment(dateTime,dateTimeFormat);
    return time.format(format);
}

/**
 * 格式化时间戳
 * @param dateUnix {number}  时间戳 秒
 * @param format     格式
 * @returns {string}
 */
function formatUnix(dateUnix,format = "YYYY-MM-DD HH:mm:ss") {
    if (dateUnix == 0) {
        return '-'
    }
    let time = moment.unix(dateUnix).local();
    return time.format(format);
}
function getTimeRange() {
    let startTime = moment().startOf('day').subtract(7,'days').toDate().getTime() / 1000;
    let endTime = moment().endOf('day').toDate().getTime() / 1000;
    return [formatUnix(startTime),formatUnix(endTime)];
}
function getTimeRange1() {
    let startTime = moment().startOf('day').toDate().getTime() / 1000;
    let endTime = moment().endOf('day').toDate().getTime() / 1000;
    return [formatUnix(startTime),formatUnix(endTime)];
}
export {
    nowUnix,
    beginOfDay,
    subtract,
    format,
    unix,
    formatUnix,
    unixDayEnd,
    unixDayStart,
    getTimeRange,
    getTimeRange1
}