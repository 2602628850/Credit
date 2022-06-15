<template>
	<view style="scroll-behavior: auto;">
		<!-- 首页轮播图 -->
		<swiper
		  indicator-dots
		  indicator-active-color="#FFFFFF"
		  circular
		  autoplay
		>
			<swiper-item
			  v-for="item in rotation"
			  :key="item.id"
			>
				<image :src = "item.url"></image>
			</swiper-item>
		</swiper>
		<!-- 首页轮播图 -->
		
		<uni-row class="demo-uni-row">
			<uni-col :xs="8" :sm="6" :md="4" :lg="6" :xl="1">
				<view class="demo-uni-col dark">
					<span >
					<image style="width: 5em;height: 5em;" src="../../static/image/index/order.png"></image>
					</span>
					<br/>
					<span style="margin-left: 7px;" >
					订单中心
					</span>
				</view>
			</uni-col>
			<uni-col :xs="8" :sm="6" :md="4" :lg="6" :xl="1">
				<view class="demo-uni-col dark">
					<span >
					<image style="width: 5em;height: 5em;" src="../../static/image/index/share.png"></image>
					</span>
					<br/>
					<span style="margin-left: 7px;">
					分享好友
					</span>
				</view>
			</uni-col>
			<uni-col :xs="8" :sm="6" :md="4" :lg="6" :xl="1">
				<view class="demo-uni-col dark">
					<span >
					<image style="width: 5em;height: 5em;" src="../../static/image/index/integral.png"></image>
					</span>
					<br/>
					<span style="margin-left: 7px;">
					积分中心
					</span>
				</view>
			</uni-col>
			<uni-col :xs="8" :sm="6" :md="4" :lg="6" :xl="1">
				<view class="demo-uni-col dark">
					<span >
					<image style="width: 5em;height: 5em;" src="../../static/image/index/index-charts.png"></image>
					</span>
					<br/>
					<span style="margin-left: 7px;">
					报表统计
					</span>
				</view>
			</uni-col>
			<uni-col :xs="8" :sm="6" :md="4" :lg="6" :xl="1">
				<view class="demo-uni-col dark">
					<span >
					<image style="width: 5em;height: 5em;" src="../../static/image/index/index-charts.png"></image>
					</span>
					<br/>
					<span style="margin-left: 24px;">
					充值
					</span>
				</view>
			</uni-col>
			<uni-col :xs="8" :sm="6" :md="4" :lg="6" :xl="1">
				<view class="demo-uni-col dark">
					<span >
					<image style="width: 5em;height: 5em;" src="../../static/image/index/index-withdraw.png"></image>
					</span>
					<br/>
					<span style="margin-left: 24px;">
					提现
					</span>
				</view>
			</uni-col>
			<uni-col :xs="8" :sm="6" :md="4" :lg="6" :xl="1">
				<view class="demo-uni-col dark">
					<span >
					<image style="width: 5em;height: 5em;" src="../../static/image/index/index-level.png"></image>
					</span>
					<br/>
					<span style="margin-left: 7px;">
					信用等级
					</span>
				</view>
			</uni-col>
			<uni-col :xs="8" :sm="6" :md="4" :lg="6" :xl="1">
				<view class="demo-uni-col dark">
					<span >
					<image style="width: 5em;height: 5em;" src="../../static/image/index/index-service.png"></image>
					</span>
					<br/>
					<span style="margin-left: 7px;">
					在线客服
					</span>
				</view>
			</uni-col>
		</uni-row>
		
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

 
<script>
	export default {
		data() {
			return {
				rotation: [
					{
						id: 1,
						url: '/static/image/lb1.jpg'
					},
					{
						id: 2,
						url: '/static/image/lb2.jpg'
					},
					{
						id: 3,
						url: '/static/image/lb3.jpg'
					},
					{
						id: 4,
						url: '/static/image/lb4.jpg'
					}
				]
			}
		},

	}
</script>
 
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