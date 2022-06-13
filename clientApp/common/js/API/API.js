import * as query from './Query'

/**
 * 获取数据接口
 * @param param
 */
function getAppSetting(param) {
    return query.get('/Customer/getAppSetting',param);
}

export {
    getAppSetting
}