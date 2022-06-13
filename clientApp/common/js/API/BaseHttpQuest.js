/**
 * 请求封装 (统一处理参数一级错误拦截)
 * @param method    {String}    请求方式 POST GET
 * @param url       {String}    请求地址
 * @param param      {{}}        参数
 * @returns {Promise<unknown>}
 */
const httpQuest = (method, url, param) => {
    return new Promise((resolve, reject) => {
        try {
            let header;
            if (method == "POST") {
                header = {
                    'X-Requested-With': 'XMLHttpRequest',
                    'Content-Type': 'application/json; charset=UTF-8',
                    'tid': 20000,
                }
            } else {
                header = {
                    'X-Requested-With': 'XMLHttpRequest',
                    "Accept": "application/json",
                    "Content-Type": "application/json; charset=UTF-8",
                    'tid': 20000,
                }
            }

            uni.request({
                url: url,
                method: method,
                data: param,
                header: header,
                success: res => {
                    let errCode = res.data.code;
                    // 统一拦截异常处理
                    switch (errCode) {
                        case 404:
                            reject({
                                message: 'Net Error'
                            })
                            break;
                        default:
                            resolve(res.data);
                            break;
                    }
                },
                fail: err => {
                    reject(err)
                }
            });
        } catch (e) {
            // 异常
            reject(e)
        }
    })
}

export default httpQuest

