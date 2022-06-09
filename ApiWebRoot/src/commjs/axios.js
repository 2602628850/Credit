import Axios from "axios";
Axios.defaults.timeout = 100000//设置超时时间
Axios.defaults.baseURL = process.env.VUE_APP_AXIOS_BASEURL+ process.env.VUE_APP_AXIOS_API //设置axios的baseUrl
Axios.defaults.withCredentials = true //允许跨域携带cookie信息
const err = (error) => {
  if (error.response) {
  //错误提醒以后根据后端提供状态进行提醒
  return Promise.reject(error)
}
}

export default{
  Axios,
  install(Vue){

    Axios.interceptors.request.use(
      config => {
        //登录成功后(Vue.ls.set('Access-Token','abcde'))需要把Access-Token存到缓存里面,以后每次请求都需要带上token
        var token=Vue.ls.get('Access-Token');
        if(token){
        //后期会把下面代码放出来
        //config.headers.Authorization =token;
        }
          return config;
      },err);

      Axios.interceptors.response.use((response) => {
        if(response.headers['pms_exp']=='1'){
          //token过期需要调用接口,刷新token,这里以后放开
          // response.post('/Account/replaceToken').then(res => {
          //   if (res.status) {//如果返回成功
          //     Vue.ls.set('Access-Token', res.data, 7 * 24 * 60 * 60 * 1000)//重新设置缓存的token值
          //   } else {
          //               //如果token已经失效了，调用退出登录的接口,刷新页面
          //               setTimeout(() => {
          //                 window.location.reload()
          //               }, 1500)
                  
          //   }
          // })

        }
        return response
       },err)

    
  }
}
