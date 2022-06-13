// 白名单
const whiteList = [
    '/pages/index/index'
]

function hasPremission(url) {
    let result = false;

    if (whiteList.indexOf(url) == -1) {
        // 白名单不包含
        result = false;
    }
    if (uni.getStorageSync('token')) {
        // 已登录
        result = true;
    }
    console.log('登录拦截----'+result)
    return result;
}

export default () => {
    uni.addInterceptor('onLoad', {
        invoke(e) {
            if (!hasPremission(e.url)) {
                uni.navigateTo({
                    url: '/pages/login'
                })
                return false;
            }
            return true;
        },
        success(e) {

        },
        fail(e) {

        }
    })
}