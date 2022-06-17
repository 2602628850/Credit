
<template>
	<view >
      <uni-row class="demo-uni-row">
      	<uni-col>
      		<view class="demo-uni-col dark_deep">1</view>
      	</uni-col>
      </uni-row>
      
      <uni-row class="demo-uni-row">
      	<uni-col :span="12">
      		<view class="demo-uni-col dark">2</view>
      	</uni-col>
      	<uni-col :span="12">
      		<view class="demo-uni-col light">3</view>
      	</uni-col>
      </uni-row>
	</view>
</template>


<style lang="scss" scoped>
	image{
		margin-left: 3.3%;
		margin-top: 3%;
	    width: 700rpx;
		height: 85%;
	}
.demo-uni-row {
	margin-bottom: 10px;
	/* QQ、字节小程序文档写有 :host，但实测不生效 */
	/* 百度小程序没有 :host，需要设置block */
	/* #ifdef MP-TOUTIAO || MP-QQ || MP-BAIDU */
	display: block;
	/* #endif */
}

/* 支付宝小程序没有 demo-uni-row 层级 */
/* 微信小程序使用了虚拟化节点，没有 demo-uni-row 层级 */
/* #ifdef MP-ALIPAY || MP-WEIXIN */
/deep/ .uni-row {
	margin-bottom: 10px;
}
/* #endif */

.demo-uni-col {
	margin-top: 7px;
	height: 120px;
	border-radius: 4px;
	
}

.dark_deep {
	background-color: #FFFFFF;
}

.dark {
	background-color: #FFFFFF;
}

.light {
	background-color: #FFFFFF;
}
</style>