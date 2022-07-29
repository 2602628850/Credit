<template>
	<navigation-bar :title="$t('share.title')"></navigation-bar>
	<app-content-view style="width: 96%;margin-left: 2%;" :show-tab-bar="false" :show-navigation-bar="true">
	<view class="imgvew">
	 <canvas canvas-id="qrcode" />
	</view>
	<view style="width: 100%;color: green;font-size: 13px;text-align: center;"  v-on:click="copyUrl()" >
		<text>
			{{$t('share.copylink')}}
		</text>
	</view>
	<view style="text-align: center;" v-on:click="copyUrl()" >
		<input class="uni-input" v-model="copyurl" style="border: 1px solid darkgray;width: 90%;margin-left: 2.5%;margin-top: 10px;"/>
		<button type="default" style="width: 96%; margin-top: 3%;margin-left:2%;border: solid 1px;border-color: gray;">{{$t('share.clicopy')}}</button>
	
	</view>

	<view class="bottonbody">
		<uni-card :is-shadow="false" is-full>
			<image src="../../static/image/share/icon-gift.png" class="bottomimg"></image>
			<text class="uni-h6" style="margin-left: 5px;">{{$t('share.bottomcontent')}}</text>
		</uni-card>

	</view>
	<view style="height: 4%;"></view>
	</app-content-view>
	<!-- <tab-bar :selected="0"></tab-bar> -->
</template>

<script>
	import uQRCode from '@/components/Sansnn-uQRCode/uqrcode/common/uqrcode.js'
	export default {
		data() {
			return {			
				copyurl: "http://credit.ceshi-api.com/#/pages/register/index?invCode="
			}
		},
		created() {
			if (!uni.getStorageSync('token')) {
			uni.reLaunch({
				url:'/pages/login/login'
			})
			return;
			}
		},
		mounted() {
			
			this.GetUserinfo()
			
		},
		methods: {
			make() {
				 uQRCode.make({
				            canvasId: 'qrcode',
				            componentInstance: this,
				            text: this.copyurl,
				            size: uni.upx2px(250),//二维码大小
				            backgroundColor: '#ffffff',//背景颜色
				            foregroundColor: '#000000',
				            fileType: 'png',
				            correctLevel: uQRCode.defaults.correctLevel,
				            success: res => {         
				            }
				    })
			},
			GetUserinfo() {
				var url = "/User/GetUserInfo";
				this.ApiGet(url).then(res => { 
					this.copyurl =this.copyurl+ res.data.invCode
					this.make();
				})
			},
			copyUrl() {
				let content =this.copyurl;
				content = typeof content === 'string' ? content : content.toString()
				//#ifndef H5
				uni.setClipboardData({
					data: content,
					success: function() {
						uni.showToast({
							title: this.$t('share.copyresult'),
							duration:2000
						});
					},
					fail:function(){
						uni.showToast({
							title: '复制失败,请重新尝试!',
							icon:"none",
							duration:2000
						});
					}
				});
				//#endif
			
				// #ifdef H5
				if(!document.queryCommandSupported('copy')){
					error('浏览器不支持')
				}
				let textarea = document.createElement("textarea")
				textarea.value = content
				textarea.readOnly = "readOnly"
				document.body.appendChild(textarea)
				textarea.select() // 选择对象
				textarea.setSelectionRange(0, content.length) //核心
				let result = document.execCommand("copy") // 执行浏览器复制命令
				if(result){
					uni.showToast({
						title: this.$t('share.copyresult'),
						duration:2000
					});
				}	
				textarea.remove()
				// #endif
			},
			// copyUrl() {
			// 	uni.setClipboardData({
			// 		data: this.copyurl,
			// 		success: () => {
			// 			uni.showToast({
			// 				title: this.$t('share.copyresult')
			// 			})
			// 		}
			// 	});

			// },

		}
	}
</script>

<style>
	.title {
		position: absolute;
		left: 0;
		width: 92%;
		z-index: 0;
		height: 30px;
		background-color: #00875a;
		padding: 4%;
		color: white;
	}

	.imgvew {
		margin-left: 35%;
		margin-top: 10%;
		
	}




	.bottonbody {
		border-radius: 3%;
		width: 90%;
		margin: 0 6% auto;
		font-size: 6px;
		font-weight: 800;
		margin-top: 10%;
		border: 1px solid darkgray;
	}

	.bottomimg {
		width: 40px;
		height: 40px;
	}
</style>
