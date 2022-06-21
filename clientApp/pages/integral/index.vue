<template>
	<view class="pagebackground">
		<navigation-bar :title="intereal"></navigation-bar>
		<view class="uni-padding-wrap uni-common-mt">
	     <view style="margin-top: 20px;">
					<el-card class="box-card" >
					<el-row :gutter="20">
						<el-col :span="11"> 
						<div style="font-size: 16px; opacity: 1;font-weight: bold;">
							{{$t('interal.currentinte')}}
						</div>
						</el-col>
						<el-col :span="13">
							<div style="font-size: 16px; opacity: 1;font-weight: bold;text-align: left;">
								0
							</div>
							<view style="margin-top:0;text-align: right;">
								
							<text class="g-icons"></text></view>
						</el-col>
					</el-row> 
			      </el-card>
				</view>
			
			
			<view style="margin-top: 20px;">
					<el-card class="box-card" style="padding: 0;" v-on:click="ToShop()">
					<el-row :gutter="20">
						<el-col :span="3"> 
						<image src="/static/image/iteral/integral-mall.png" style="width: 30px;height: 30px;"></image>
						</el-col>
						<el-col :span="21">
							<div style="font-size: 16px; opacity: 1;font-weight: bold;">
								{{$t('interal.inteshop')}}
							</div>
							<view style="margin-top:10px;text-align: right;">
								
							<text class="g-icons"></text></view>
						</el-col>
					</el-row> 
					<el-row :gutter="20">
						<el-col :span="3"> 
						<image src="/static/image/iteral/integral-order.png" style="width: 30px;height: 30px;"></image>
						</el-col>
						<el-col :span="21">
							<div style="font-size: 16px; opacity: 1;font-weight: bold;">
								{{$t('interal.inteorder')}}
							</div>
							<view style="margin-top:10px;text-align: right;">
								
							<text class="g-icons"></text></view>
						</el-col>
					</el-row> 
			      </el-card>
				</view>
			
			
<view style="margin-top: 20px;">{{$t('interal.interenwu')}}</view>	
<view style="margin-top: 9px;">
		<el-card class="box-card" >
		<el-row :gutter="20">
			<el-col :span="3"> 
				<image src="/static/image/iteral/integral-credit.png"
					style="width: 30px;height: 30px;"></image>
			</el-col>
			<el-col :span="21">
				<div style="font-size: 16px; opacity: 1;font-weight: bold;">
					{{$t('interal.finishchaka')}}
				</div>
				<view style="font-size: 8px"><span>{{$t('interal.chakareason')}}</span></view>
				
				<view style="margin-top:10px;text-align: right;">
					
				<span> <el-button type="primary">{{$t('interal.tofinish')}}</el-button> </span></view>
			</el-col>
		</el-row> 
    
		<el-row :gutter="20">
			<el-col :span="3"> 
				<image src="/static/image/iteral/integral-repayment.png"
					style="width: 30px;height: 30px;"></image>
			</el-col>
			<el-col :span="21">
				<div style="font-size: 16px; opacity: 1;font-weight: bold;">
					{{$t('interal.finishdaikuan')}}
				</div>
				<view style="font-size: 8px"><span>	{{$t('interal.finishdaikuanreason')}}</span></view>
				
				<view style="margin-top:10px;text-align: right;">
					
				<span> <el-button type="primary">{{$t('interal.tofinish')}}</el-button> </span></view>
			</el-col>
		</el-row> 
			<el-row :gutter="20">
				<el-col :span="3"> 
				<image src="/static/image/iteral/integral-share.png"
					style="width: 30px;height: 30px;"></image>
				</el-col>
				<el-col :span="21">
					<div style="font-size: 16px; opacity: 1;font-weight: bold;">
						{{$t('interal.sharfrend')}}
					</div>
					<view style="font-size: 8px"><span>{{$t('interal.sharreason')}}</span></view>
					
					<view style="margin-top:10px;text-align: right;">
						
					<span> <el-button type="primary">{{$t('interal.tofinish')}}</el-button> </span></view>
				</el-col>
			</el-row> 
	      </el-card>
		</view>


		</view>
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
