// #ifdef H5
console.log('h5')
// 请求域名http://localhost:8003/v1
let host = 'http://api.credit.ceshi-api.com/v1';
//let host = 'http://localhost:8003/v1';
// #endif
// #ifdef APP-PLUS
console.log('app')
// 请求域名
 let host = 'http://api.credit.ceshi-api.com/v1';
//let host = '移动端编译这个';
// #endif

const base = {
    host: host
}

export default base;