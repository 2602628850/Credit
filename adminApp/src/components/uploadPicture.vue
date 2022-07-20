<template>
 <el-form :model="form">
    <el-form-item label="" :label-width="formLabelWidth" style="float:left;" >
      <el-upload
        ref="upload"
        :action="uploadurl"
        accept="image/png,image/gif,image/jpg,image/jpeg"
        list-type="picture-card"
        :limit=limitNum
        :auto-upload="false"
        :on-exceed="handleExceed"
        :before-upload="handleBeforeUpload"
        :on-preview="handlePictureCardPreview"
        :on-remove="handleRemove"
        :on-success="uploadSuccess"
        :file-list="fileList"
        >
           <el-icon style=""><Plus /></el-icon>
      </el-upload>
    </el-form-item>
    <el-form-item>
      <el-button size="small" type="default"  @click="uploadFile" style="margin-left:10px;margin-top:30px;background-color:gray;color:white;">上传到服务</el-button>
    </el-form-item>
  </el-form>
</template>

<script>
export default {
  name:"DS",
  data() {
    return{
      uploadurl:  process.env.VUE_APP_AXIOS_BASEURL+ process.env.VUE_APP_AXIOS_API+"/Upload/Image",
      fontsize:'0px',
      formLabelWidth: '0px',
      limitNum: 1,
      form: {},
      fileList:[]
    }
  },
  props:["logourl"],//接收父组件传过来的logo图片路径
  methods: {
    // 上传文件之前的钩子
    handleBeforeUpload(file){
      console.log('before')
      if(!(file.type === 'image/png' || file.type === 'image/gif' || file.type === 'image/jpg' || file.type === 'image/jpeg')) {
        this.$notify.warning({
          title: '警告',
          message: '请上传格式为image/png, image/gif, image/jpg, image/jpeg的图片'
        })
      }
      let size = file.size / 1024 / 1024
      if(size > 5) {
        this.$notify.warning({
          title: '警告',
          message: '图片大小不能大于5M'
        })
      }
    },
    updateUrl(val){
    this.fileList=[];//置空图片
     this.$emit('update:logourl',val)//给首页的logo复制
    if(val){
      this.fileList.push({ url: val});//只有不为空的时候才会有默认图片
      }
    },
    // 文件超出个数限制时的钩子
    handleExceed(files, fileList) {
       console.log(files, fileList);
    },
    // 文件列表移除文件时的钩子
    handleRemove(file, fileList) {
      this.$emit('update:logourl','')
      console.log(file, fileList);
    },
    // 点击文件列表中已上传的文件时的钩子
    handlePictureCardPreview(file) {
      console.log(file)
    },
    uploadFile() {
      this.$refs.upload.submit()
    },
    uploadSuccess(obj){
       if (obj.success) {
          //图片上传成功以后改变父组件的值,这里的logourl对应父组件里面的logo
           this.$emit('update:logourl',obj.data.src )
       } else {
    // this.$message.error('操作失败')
  }
    }

  } 
}
</script>
<style>
               .el-upload--picture-card{
                    width: 100px;
                    height: 100px;
                }
                 .el-upload{
                    width: 100px;
                    height: 100px;
                    
                     
                }
                .el-upload-list--picture-card .el-upload-list__item{
                    width: 100px;
                    height: 100px;
                    line-height: 100px;
                }
                .el-upload-list--picture-card .el-upload-list__item-thumbnail{
                    width: 100px;
                    height: 100px;
                    line-height: 100px;
                }
                .avatar{
                    width: 100px;
                    height: 100px;
                }
</style>