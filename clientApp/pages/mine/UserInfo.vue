<template>
	<navigation-bar :title="$t('setUserInfo.title')"></navigation-bar>
	<view style="height: 1px"></view>
	<view style="margin-top: 20px;margin-bottom: 20px;" class="flex-row-center" @click="upload">
		<view style="position: relative">
			<image class="mine-user-info-image" :src="editItem.headImage"></image>
			<view class="mine-user-info-img-sm text-white bg-primary flex-row-center iconfont icon-xiangce"></view>
		</view>
	</view>
	<app-content-view :show-tab-bar="true" :show-navigation-bar="true">
		<register-input-item :tip="$t('setUserInfo.nickname')" class="mgt">
			<template v-slot:img>
				<view class="input-icon iconfont icon-youxiang"></view>
			</template>
			<template v-slot:default>
				<input class="input" v-model="editItem.nickname" />
			</template>
		</register-input-item>
		<view class="mgt w100 margin-left-right-20 flex-row-start text-small">
			<view class="mgl agree text-primary"></view>
		</view>
		<view class="button-primary margin-left-right-20 flex-row-center" @click="doRegister">
			{{$t('setUserInfo.button')}}
		</view>
	</app-content-view>
</template>

<script>
	import base from "../../common/js/api/BaseUrl.js"
	import RegisterTopItem from "../register/register-top-item";
	import RegisterInputItem from "../register/register-input-item";
	export default {
		components: {
			RegisterInputItem,
			RegisterTopItem
		},
		data() {
			return {
				namexxxx: '77777',
				headImage: '',
				editItem: {
					headImage: ''
				},
			}
		},
		mounted() {
			if (!uni.getStorageSync('token')) {
				uni.reLaunch({
					url: '/pages/login/login'
				})
			}
			this.GetUserinfo()
		},
		methods: {
			showMsg(msg) {
				uni.showToast({
					title: msg,
					duration: 2000,
				})
			},
			GetUserinfo() {
				var url = "/User/GetUserInfo";
				this.ApiGet(url).then(res => {
					this.editItem = res.data
				})
			},
			upload() {
				uni.chooseImage({
					count: 1,
					sizeType: ['original', 'compressed'], //可以指定是原图还是压缩图，默认二者都有
					sourceType: ['album'], //从相册选择
					success: res => {
						const tempFilePaths = res.tempFilePaths;
						const uploadTask = uni.uploadFile({
							url: 'http://localhost:8003/v1/Upload/HeadImage',
							filePath: tempFilePaths[0],
							name: 'file',
							formData: {
								'user': 'test'
							},
							success: res => {
								var data = JSON.parse(JSON.stringify(res.data))
								var obj = JSON.parse(data)
								console.log(obj)
								///this.editItem.xxxx="yyyyy"
								//console.log(this.editItem) 
								this.editItem.headImage = obj.data.imgUrl;
								console.log(this.editItem.headImage)
							}
						});

						uploadTask.onProgressUpdate(function(res) {
							// this.percent = res.progress;
							console.log('上传进度' + res.progress);
							console.log('已经上传的数据长度' + res.totalBytesSent);
							console.log('预期需要上传的数据总长度' + res.totalBytesExpectedToSend);
						});
					},
					error: function(e) {
						console.log(e);
					}
				});
			},
			doRegister() {
				if (this.editItem.nickname.split(" ").join("").length === 0) {
					var msg = this.$t('setUserInfo.msge');
					this.showMsg(msg)
					return;
				}
				var img = this.headImage;
				debugger
				var url = "/User/UpdateUser";
				this.ApiPost(url, this.editItem).then(res => {
					if (res.data == "success") {
						this.showMsg(this.$t('setUserInfo.msg'));
						//注册成功后登录
						uni.navigateTo({
							url: '/pages/mine/mine'
						})
						return;
					} else {
						this.showMsg(res.data);
					}

				})

			}
		}
	}
</script>

<style>
	.mine-user-info-image {
		width: 120px;
		height: 120px;
		border-radius: 50%;
	}

	.mine-user-info-img-sm {
		position: absolute;
		bottom: 8px;
		right: 8px;
		width: 30px;
		height: 30px;
		border-radius: 50%;
		border-width: 2px;
		border-color: white;
		border-style: solid;
		font-size: 20px;
		box-sizing: border-box;
	}

	.mine-user-info-button {
		height: 44px;
		margin: 40px 20px 0px 20px;
	}

	.input-icon {
		font-size: 18px;
	}

	.input {
		height: 44px;
		font-size: 16px;
		flex: 1;
	}

	.input-placeholder {
		font-size: 12px;
	}

	.uni-input-input {
		font-size: 12px;
	}

	.agree {
		box-sizing: border-box;
		border-bottom-color: #00875a;
		border-bottom-style: solid;
		border-bottom-width: 1px;
	}
</style>
