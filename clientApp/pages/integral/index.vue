<template>
	<view class="pagebackground">
		<navigation-bar :title="intereal"></navigation-bar>
		<app-content-view style="width: 96%;margin-left: 2%;" :show-tab-bar="false" :show-navigation-bar="true">
		
		<view class="uni-padding-wrap uni-common-mt">
	     <view style="margin-top: 20px;">
					<uni-card class="box-card" >
					<uni-row :gutter="20">
						<uni-col :span="11"> 
						<view style="font-size: 16px; opacity: 1;font-weight: bold;">
							{{$t('interal.currentinte')}}
						</view>
						</uni-col>
						<uni-col :span="13">
							<view style="font-size: 16px; opacity: 1;font-weight: bold;text-align: left;">
								0
							</view>
							<view style="text-align: right;">
							<text class="g-icons"></text></view>
						</uni-col>
					</uni-row> 
			      </uni-card>
				</view>
			
			
			<view style="margin-top: 20px;">
					<uni-card class="box-card" style="padding: 0;">
					<uni-row :gutter="20" v-on:click="ToShop()">
						<uni-col :span="3"> 
						<image src="/static/image/iteral/integral-mall.png" style="width: 30px;height: 30px;"></image>
						</uni-col>
						<uni-col :span="21">
							<view style="font-size: 16px; opacity: 1;font-weight: bold;">
								{{$t('interal.inteshop')}}
							</view>
							<view style="margin-top:10px;text-align: right;">
								
							<text class="g-icons"></text></view>
						</uni-col>
					</uni-row> 
					<uni-row :gutter="20">
						<uni-col :span="3"> 
						<image src="/static/image/iteral/integral-order.png" style="width: 30px;height: 30px;"></image>
						</uni-col>
						<uni-col :span="21">
							<view style="font-size: 16px; opacity: 1;font-weight: bold;">
								{{$t('interal.inteorder')}}
							</view>
							<view style="margin-top:10px;text-align: right;">
								
							<text class="g-icons"></text></view>
						</uni-col>
					</uni-row> 
			      </uni-card>
				</view>
			
			
<view style="margin-top: 20px;">{{$t('interal.interenwu')}}</view>	
<view style="margin-top: 9px;">
		<uni-card class="box-card" >
		<uni-row :gutter="20">
			<uni-col :span="3"> 
				<image src="/static/image/iteral/integral-credit.png"
					style="width: 30px;height: 30px;"></image>
			</uni-col>
			<uni-col :span="21">
				<view style="font-size: 16px; opacity: 1;font-weight: bold;">
					{{$t('interal.finishchaka')}}
				</view>
				<view style="font-size: 8px"><text>{{$t('interal.chakareason')}}</text></view>
				
				<view style="margin-top:10px;text-align: right;">
					
				<text> <el-button type="primary">{{$t('interal.tofinish')}}</el-button> </text></view>
			</uni-col>
		</uni-row> 
    
		<uni-row :gutter="20">
			<uni-col :span="3"> 
				<image src="/static/image/iteral/integral-repayment.png"
					style="width: 30px;height: 30px;"></image>
			</uni-col>
			<uni-col :span="21">
				<view style="font-size: 16px; opacity: 1;font-weight: bold;">
					{{$t('interal.finishdaikuan')}}
				</view>
				<view style="font-size: 8px"><span>	{{$t('interal.finishdaikuanreason')}}</span></view>
				
				<view style="margin-top:10px;text-align: right;">
					
				<span> <el-button type="primary">{{$t('interal.tofinish')}}</el-button> </span></view>
			</uni-col>
		</uni-row> 
			<uni-row :gutter="20">
				<uni-col :span="3"> 
				<image src="/static/image/iteral/integral-share.png"
					style="width: 30px;height: 30px;"></image>
				</uni-col>
				<uni-col :span="21">
					<view style="font-size: 16px; opacity: 1;font-weight: bold;">
						{{$t('interal.sharfrend')}}
					</view>
					<view style="font-size: 8px"><span>{{$t('interal.sharreason')}}</span></view>
					
					<view style="margin-top:10px;text-align: right;">
						
					<span> <el-button type="primary">{{$t('interal.tofinish')}}</el-button> </span></view>
				</uni-col>
			</uni-row> 
	      </uni-card>
		</view>
		</view>
		</app-content-view>
	</view>

</template>
<script>
	export default {
		
			data() {
				return {
	              intereal:this.$t('interal.intereal')
				}
			},
			methods:{
				ToShop(){
					uni.navigateTo({
						url:"/pages/integral/mall"
					})
				}
			},
		}
</script>

<style>
	@font-face {
		font-family: gicons;
		src: url(/static/famaly/font_1841497_jvc2prjmtkh.5ed93165.ttf) format("truetype")
	}

	.g-icons {
		font-family: gicons;
		text-decoration: none;
		text-align: center
	}
	
</style>
<style>
.el-row {
  margin-bottom: 20px;
}
.el-row:last-child {
  margin-bottom: 0;
}
.el-col {
  border-radius: 4px;
} 
.logo {
		width: 100%;
		height: 100px;
	}
.grid-content {
  border-radius: 4px;
  min-height: 36px;
}
</style>
