<template>
	<view class="pagebackground">
		<navigation-bar title="积分中心"></navigation-bar>
		<view class="uni-padding-wrap uni-common-mt">
	     <view style="margin-top: 20px;">
					<el-card class="box-card" >
					<el-row :gutter="20">
						<el-col :span="6"> 
						<div style="font-size: 16px; opacity: 1;font-weight: bold;">
							当前积分：
						</div>
						</el-col>
						<el-col :span="18">
							<div style="font-size: 16px; opacity: 1;font-weight: bold;text-align: left;">
								0
							</div>
							<view style="margin-top:10px;text-align: right;">
								
							<text class="g-icons"></text></view>
						</el-col>
					</el-row> 
			      </el-card>
				</view>
			
			
			<view style="margin-top: 20px;">
					<el-card class="box-card" >
					<el-row :gutter="20">
						<el-col :span="3"> 
						<image src="/static/image/iteral/integral-mall.png" style="width: 30px;height: 30px;"></image>
						</el-col>
						<el-col :span="21">
							<div style="font-size: 16px; opacity: 1;font-weight: bold;">
								积分商城
							</div>
							<view style="margin-top:10px;text-align: right;">
								
							<text class="g-icons"></text></view>
						</el-col>
					</el-row> 
			      </el-card>
				</view>
			<view style="margin-top: 0px;">
					<el-card class="box-card" >
					<el-row :gutter="20">
						<el-col :span="3"> 
						<image src="/static/image/iteral/integral-order.png" style="width: 30px;height: 30px;"></image>
						</el-col>
						<el-col :span="21">
							<div style="font-size: 16px; opacity: 1;font-weight: bold;">
								积分订单
							</div>
							<view style="margin-top:10px;text-align: right;">
								
							<text class="g-icons"></text></view>
						</el-col>
					</el-row> 
			      </el-card>
				</view>
			
			
<view style="margin-top: 20px;">积分任务</view>	
<view style="margin-top: 9px;">
		<el-card class="box-card" >
		<el-row :gutter="20">
			<el-col :span="3"> 
				<image src="/static/image/iteral/integral-credit.png"
					style="width: 30px;height: 30px;"></image>
			</el-col>
			<el-col :span="21">
				<div style="font-size: 16px; opacity: 1;font-weight: bold;">
					完成查卡
				</div>
				<view style="font-size: 8px"><span>完成一次查卡自动获得1积分</span></view>
				
				<view style="margin-top:10px;text-align: right;">
					
				<span> <el-button type="primary">去完成</el-button> </span></view>
			</el-col>
		</el-row> 
      </el-card>
	</view>
<view style="margin-top: 0px;">
		<el-card class="box-card" >
		<el-row :gutter="20">
			<el-col :span="3"> 
				<image src="/static/image/iteral/integral-repayment.png"
					style="width: 30px;height: 30px;"></image>
			</el-col>
			<el-col :span="21">
				<div style="font-size: 16px; opacity: 1;font-weight: bold;">
					完成代还
				</div>
				<view style="font-size: 8px"><span>完成一次代还贷款自动获得20积分</span></view>
				
				<view style="margin-top:10px;text-align: right;">
					
				<span> <el-button type="primary">去完成</el-button> </span></view>
			</el-col>
		</el-row> 
      </el-card>
	</view>
	<view style="margin-top: 0px;">
			<el-card class="box-card" >
			<el-row :gutter="20">
				<el-col :span="3"> 
				<image src="/static/image/iteral/integral-share.png"
					style="width: 30px;height: 30px;"></image>
				</el-col>
				<el-col :span="21">
					<div style="font-size: 16px; opacity: 1;font-weight: bold;">
						邀请好友
					</div>
					<view style="font-size: 8px"><span>成功邀请一名好友成为平台正式会员自动获得100积分</span></view>
					
					<view style="margin-top:10px;text-align: right;">
						
					<span> <el-button type="primary">去完成</el-button> </span></view>
				</el-col>
			</el-row> 
	      </el-card>
		</view>


		</view>
	</view>

</template>
<script>
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
