<template>
	<uni-page-head uni-page-head-type="default">
		<div class="uni-page-head" style="background-color: rgb(244, 245, 247); color: rgb(0, 0, 0);">
			<div class="uni-page-head-hd">
				<div class="uni-page-head-btn" style="display: none;"><i class="uni-btn-icon"
						style="color: rgb(0, 0, 0); font-size: 27px;"></i></div>
				<div class="uni-page-head-ft"></div>
			</div>
			<div class="uni-page-head-bd">
				<div class="uni-page-head__title" style="font-size: 16px; opacity: 1;">
					{{$t('prohall.title')}}
				</div>
			</div>
			<!---->
			<div class="uni-page-head-ft"></div>
		</div>
		<div class="uni-placeholder"></div>
	</uni-page-head>
	<view style="margin-top:20px;"  @click="tocredit">
		<el-card class="box-card" >
		<el-row :gutter="20">
			<el-col :span="6"> 
				<image class="logo" src="/static/icons/task-credit.png"></image>
			</el-col>
			<el-col :span="6"> 
			</el-col>
			<el-col :span="10">
				<div style="font-size: 16px; opacity: 1;font-weight: bold;">
					{{$t('prohall.repayment')}}
				</div>
				<view style="font-size: 8px"><span>{{$t('prohall.repaycon')}}</span></view>
				
				<view style="margin-top:30px;text-align: right;">
					
				<span>	<el-button type="primary">{{$t('prohall.repaysend')}}</el-button></span></view>
			</el-col>
		</el-row> 
      </el-card>
	</view>
	<view style="margin-top:20px;">
		<el-card class="box-card" >
		<el-row :gutter="20">
			<el-col :span="6"> 
				<image class="logo" src="/static/icons/task-repayment.png"></image>
			</el-col>
			<el-col :span="16">
				<div style="font-size: 16px; opacity: 1;font-weight: bold;">
					{{$t('prohall.loantitle')}}
				</div>
				<view style="font-size: 8px"><span>{{$t('prohall.loancon')}}</span></view>
				
				<view style="margin-top:30px;text-align: right;">
					
				<span> <el-button type="primary">{{$t('prohall.loansend')}}</el-button> </span></view>
			</el-col>
		</el-row> 
      </el-card>
	</view>
	<view style="margin-top:20px;">
		<el-card class="box-card" >
		<el-row :gutter="20">
			<el-col :span="6"> 
				<image class="logo" src="/static/icons/task-smeloan.png"></image>
			</el-col>
			<el-col :span="4"> 
			</el-col>
			<el-col :span="12">
				<div style="font-size: 16px; opacity: 1;font-weight: bold;">
					{{$t('prohall.buytitle')}}
				</div>
				<view style="font-size: 8px"><span>{{$t('prohall.buycon')}}</span></view>
				
				<view style="margin-top:30px;text-align: right;">
					
				<span>	<el-button type="primary">{{$t('prohall.buysend')}}</el-button></span></view>
			</el-col>
		</el-row> 
      </el-card>
	</view>
	 <tab-bar :selected="1"></tab-bar>
</template>

<script>
	export default {
		data() {
			return {

			}
		},
		methods: {
			tocredit() {
				// https://uniapp.dcloud.io/api/router.html#navigateto 自带路由
				uni.reLaunch({
					url: '/pages/prohall/creditIndex'
				})
			}
		}
	}
</script>

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
