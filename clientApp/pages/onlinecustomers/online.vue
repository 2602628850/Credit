<template>
	<navigation-bar :title="ontitle"></navigation-bar>
	<app-content-view style="width: 96%;margin-left: 2%;" :show-tab-bar="false" :show-navigation-bar="true">
	<view class="imgvew">
		<image src="../../static/image/share/share.png" style="width: 150px; height: 150px;" draggable="true"></image>
	</view>
	<uni-card class="box-card" style="height: 100px;">
	<uni-row :gutter="20" style="margin-top: 5%;" >
		
		<uni-col :span="24">
			<view style="font-size: 16px; opacity: 1;font-weight: bold;text-align: center;">
				{{$t('kefu.kefutm')}}
			</view>
			<view style="font-size: 8px;text-align: center;"><text>{{$t('kefu.ketime')}}</text></view>
			
			
		</uni-col>
	</uni-row> 
	</uni-card>

	
	<view style="height: 4%;"></view>
	</app-content-view>
	<!-- <tab-bar :selected="0"></tab-bar> -->
</template>

<script>
	export default {
		data() {
			return {
				ontitle:this.$t('kefu.lineservice')
			}
		},
		methods: {
			copyUrl() {
				uni.setClipboardData({
					data: this.copyurl,
					success: () => {
						uni.showToast({
							title: this.$t('share.copyresult')
						})
					}
				});

			},

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
		width: 150px;
		height: 100px;
		display: block;
		margin: 20% auto;
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
