<template>
	<navigation-bar :title="$t('share.title')"></navigation-bar>
	<view>
		<text class="title">{{$t('share.titlenexe')}}</text>
	</view>

	<view class="imgvew">
		<image src="../../static/image/share/share.png" style="width: 150px; height: 150px;" draggable="true"></image>
	</view>
	<view style="width: 100%;color: green;font-size: 13px;text-align: center;">
		<text>
			{{$t('share.copylink')}}
		</text>
	</view>
	<view class="mt-4" style="width: 90%;margin-left: 5%;margin-top: 10%;">
	    <el-input v-model="copyurl">
	      <template #append>
			 <button type="primary" size="mini"
			 	@click="copyUrl()">{{$t('share.bottonc')}}</button>
			  </template>
	    </el-input>
	
	  </view>

	<view class="bottonbody">
		<uni-card :is-shadow="false" is-full>
			<image src="../../static/image/share/icon-gift.png" class="bottomimg"></image>
			<text class="uni-h6"
				style="margin-left: 5px;">{{$t('share.bottomcontent')}}</text>
		</uni-card>

	</view>
	<view style="height: 4%;"></view>
<tab-bar :selected="0"></tab-bar>
</template>

<script>
	export default {
		data() {
			return {
				copyurl:"https://www.thirdcredit.net?t=25202"
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

	.bottomimg{
		width: 40px;height: 40px;
	}
</style>
