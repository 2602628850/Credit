<template>
<el-button type="primary">Primary</el-button>
<h1>axios</h1>
</template>
<script>
export default {
  name: "AxioxDemo",
  data() {
    return {
      tesdto:{name:"you",no:"to"}
    };
  },
  components: {
    
  },
  methods: {
    //-------post提交后台接收的数据是[FromBody] TesDto testo呢种对象形式的
    getdata() {
      this.$Http.post('/Tes/getval',this.tesdto)
      .then(res=>{
        alert(res.data)
     }) .catch((err) => {
        console.log(err)
        });
   },
    //------后台接收的数据是[FromBody] TesDto testo呢种对象形式的

    //-------get提交后台接收的数据是string name,string no呢种对象形式的
    getdataquery() {
      var param=new URLSearchParams();
      param.append('name','tttt');
      param.append('no','xxxx');
      this.$Http.get('/Tes/getvalquery', {params:param})
      .then(res=>{
        alert(res.data)
     }) .catch((err) => {
        console.log(err)
        });
   },
    //------后台接收的数据是[FromBody] TesDto testo呢种对象形式的
  },
  mounted(){
     //this.getdata(); //post提交
     this.getdataquery(); //get提交
  }
};
</script>