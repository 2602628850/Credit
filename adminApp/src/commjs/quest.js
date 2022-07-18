import Axios from  './axios.js'
const Quest = {
    post (name, params) {
        return Axios.post(name,params);
    },
    get (name, params) {
        return Axios.Axios().get(name,{params: params})
    }
}
export default Quest;