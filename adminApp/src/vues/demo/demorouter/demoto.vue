<template>
<!--<router-link :to="`/axioxdemo`" >测试axios</router-link>-->
<!-- <router-link :to="{ name: 'toapp3' }" >测试axios</router-link> -->
<h1>已经跳转到另一个页面</h1>
</template>
<script>
export default {
  name: "DeMoTo",
  data() {
    return {
    };
  },
  components: {
    
  },
  methods: {
    gohone() {
   
    },
  },
  mounted(){
    //alert(this.$route.query.id) //获取路由参数
  }
};
</script>