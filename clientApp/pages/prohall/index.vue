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
					大厅
				</div>
			</div>
			<!---->
			<div class="uni-page-head-ft"></div>
		</div>
		<div class="uni-placeholder"></div>
	</uni-page-head>
	<view style="margin-top:10px;">
		<el-card class="box-card" >
		<el-row :gutter="20">
			<el-col :span="6"> 
				<image class="logo" src="/static/icons/task-credit.png"></image>
			</el-col>
			<el-col :span="6"> 
			</el-col>
			<el-col :span="10">
				<div style="font-size: 16px; opacity: 1;font-weight: bold;">
					信用卡代还专区
				</div>
				<view style="font-size: 8px"><span>代还信用卡账单,即时获取收益</span></view>
				
				<view style="margin-top:30px;text-align: right;">
					
				<span>	<el-button type="primary">去还款</el-button></span></view>
			</el-col>
		</el-row> 
      </el-card>
	</view>
	<view style="margin-top:10px;">
		<el-card class="box-card" >
		<el-row :gutter="20">
			<el-col :span="6"> 
				<image class="logo" src="/static/icons/task-repayment.png"></image>
			</el-col>
			<el-col :span="16">
				<div style="font-size: 16px; opacity: 1;font-weight: bold;">
					贷款代还专区
				</div>
				<view style="font-size: 8px"><span>P2P短期借贷，安全稳定，每日返还收益，先息后本</span></view>
				
				<view style="margin-top:30px;text-align: right;">
					
				<span> <el-button type="primary">去借出</el-button> </span></view>
			</el-col>
		</el-row> 
      </el-card>
	</view>
	<view style="margin-top:10px;">
		<el-card class="box-card" >
		<el-row :gutter="20">
			<el-col :span="6"> 
				<image class="logo" src="/static/icons/task-smeloan.png"></image>
			</el-col>
			<el-col :span="4"> 
			</el-col>
			<el-col :span="12">
				<div style="font-size: 16px; opacity: 1;font-weight: bold;">
					SME Loans
				</div>
				<view style="font-size: 8px"><span>购买企业期权，到期获得高回报收益</span></view>
				
				<view style="margin-top:30px;text-align: right;">
					
				<span>	<el-button type="primary">去购买</el-button></span></view>
			</el-col>
		</el-row> 
      </el-card>
	</view>
</template>

<script>
	export default {
		data() {
			return {

			}
		},
		methods: {

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
