// #ifdef H5
console.log('h5')
// 请求域名
let host = 'http://api.ceshi-api.com/v1.0';
// #endif
// #ifdef APP-PLUS
console.log('app')
// 请求域名
let host = '移动端编译这个';
// #endif

const base = {
    host: host
}

export default base;