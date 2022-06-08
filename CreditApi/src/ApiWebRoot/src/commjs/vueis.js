import Storage from 'vue-ls';
const options = {
  namespace: 'vuejs__', // key键前缀
  name: 'ls', // 命名Vue变量.[ls]或this.[$ls],
  storage: 'local', // 存储名称: session, local, memory
};
  export default{
    install(Vue){
      Vue.use(Storage, options);
    }
  }