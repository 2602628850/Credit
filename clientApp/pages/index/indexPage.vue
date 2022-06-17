<template>
	<view class="topview">
		<view class="created">
			<text>Third Credit</text>
		</view>
		<!-- 首页轮播图 indexpages.swipers控制显示中文还是英文图标-->
				<swiper v-if="$t('indexpages.swipers')=='0'" style="text-align: center;" indicator-dots indicator-active-color="#FFFFFF" circular autoplay>
					<swiper-item v-for="item in rotation" :key="item.id">
						<image :src="item.url"></image>
					</swiper-item>
				</swiper>
				<swiper v-if="$t('indexpages.swipers')=='1'" style="text-align: center;" indicator-dots indicator-active-color="#FFFFFF" circular autoplay>
					<swiper-item v-for="item in enrotation" :key="item.id">
						<image :src="item.url"></image>
					</swiper-item>
				</swiper>
				<!-- 首页轮播图 -->
		<uni-row class="demo-uni-row"  style="margin-left: 6%;">
			<uni-col :xs="8" :sm="6" :md="5" :lg="6" :xl="1">
				<view class="demo-uni-col dark">
					<span>
						<image style="width: 5em;height: 5em;" src="../../static/image/index/order.png"></image>
					</span>
					<br />
					<span style="margin-left: 7px;">
						{{$t('indexpages.order')}}
					</span>
				</view>
			</uni-col>
			<uni-col :xs="8" :sm="6" :md="4" :lg="6" :xl="1">
				<view class="demo-uni-col dark">
					<span>
						<image style="width: 5em;height: 5em;" src="../../static/image/index/share.png"></image>
					</span>
					<br />
					<span style="margin-left: 7px;">
						分享好友
					</span>
				</view>
			</uni-col>
			<uni-col :xs="8" :sm="6" :md="4" :lg="6" :xl="1">
				<view class="demo-uni-col dark">
					<span>
						<image style="width: 5em;height: 5em;" src="../../static/image/index/integral.png"></image>
					</span>
					<br />
					<span style="margin-left: 7px;">
						积分中心
					</span>
				</view>
			</uni-col>
			<uni-col :xs="8" :sm="6" :md="4" :lg="6" :xl="1">
				<view class="demo-uni-col dark">
					<span>
						<image style="width: 5em;height: 5em;" src="../../static/image/index/index-charts.png"></image>
					</span>
					<br />
					<span style="margin-left: 7px;">
						报表统计
					</span>
				</view>
			</uni-col>
			<uni-col :xs="8" :sm="6" :md="4" :lg="6" :xl="1">
				<view class="demo-uni-col dark">
					<span>
						<image style="width: 5em;height: 5em;" src="../../static/image/index/index-charts.png"></image>
					</span>
					<br />
					<span style="margin-left: 24px;">
						充值
					</span>
				</view>
			</uni-col>
			<uni-col :xs="8" :sm="6" :md="4" :lg="6" :xl="1">
				<view class="demo-uni-col dark">
					<span>
						<image style="width: 5em;height: 5em;" src="../../static/image/index/index-withdraw.png">
						</image>
					</span>
					<br />
					<span style="margin-left: 24px;">
						提现
					</span>
				</view>
			</uni-col>
			<uni-col :xs="8" :sm="6" :md="4" :lg="6" :xl="1">
				<view class="demo-uni-col dark">
					<span>
						<image style="width: 5em;height: 5em;" src="../../static/image/index/index-level.png"></image>
					</span>
					<br />
					<span style="margin-left: 7px;">
						信用等级
					</span>
				</view>
			</uni-col>
			<uni-col :xs="8" :sm="6" :md="4" :lg="6" :xl="1">
				<view class="demo-uni-col dark">
					<span>
						<image style="width: 5em;height: 5em;" src="../../static/image/index/index-service.png"></image>
					</span>
					<br />
					<span style="margin-left: 7px;">
						在线客服
					</span>
				</view>
			</uni-col>
		</uni-row>
		<view class="titlecom">
			<text>Account</text>
		</view>

		<uni-row class="demo-uni-row radios product" style="margin-left: 1.5%;">
			<view style="padding: 20px 5px;">
				<uni-col :span="3" :offset="1">
					<view class="demo-uni-col-anniu dark">
						<text style="color: green;">$10000</text><br />
						<text style="margin-left: 10%;">余额</text>
					</view>
				</uni-col>
				<uni-col :span="9" :offset="3">
					<view class="demo-uni-col-anniu light">
						<text style="margin-left: 40%;color: green;">3</text><br />
						<text>今日剩余查卡次数</text>
					</view>
				</uni-col>
				<uni-col :span="5" :offset="2">
					<view class="demo-uni-col-anniu light">
						<text style="margin-left: 10%;color: green;">+$0</text><br />
						<text>今日收入</text>
					</view>
				</uni-col>
			</view>
		</uni-row>

		<view class="titlecom">
			<text>Product feature</text>
		</view>
		<uni-row class="demo-uni-row radios product" style="margin-left: 1.5%;">
			<uni-col :span="18" :offset="1">
				<view class="demo-uni-col-anniu1 dark">
					<text class="productval">1</text>
					<view class="productcont">
						<text class="producttile">产品介绍</text><br />
						<text class="marginleft10">什么是信用卡代还</text>
					</view>

				</view>
			</uni-col>

			<uni-col :span="5" style="margin-top: 10%;">
				<text>
					<image src="/static/image/index/index-product.png" style="width: 50px;height: 50px;"></image>
				</text>
			</uni-col>
		</uni-row>



		<uni-row class="demo-uni-row radios product" style="margin-left: 1.5%;">
			<uni-col :span="18" :offset="1">
				<view class="demo-uni-col-anniu1 dark">
					<text class="productval">2</text>
					<view class="productcont">
						<text class="producttile">信用等级</text><br />
						<text class="marginleft10">有效客户通过完成“推荐人数”和“还款次数”提升自己的信用等级（VIP等级)</text>
					</view>

				</view>
			</uni-col>

			<uni-col :span="5" style="margin-top: 10%;">
				<text>
					<image src="/static/image/index/index-product.png" style="width: 50px;height: 50px;"></image>
				</text>
			</uni-col>
		</uni-row>


		<uni-row class="demo-uni-row radios product" style="margin-left: 1.5%;">
			<uni-col :span="18" :offset="1">
				<view class="demo-uni-col-anniu1 dark">
					<text class="productval">3</text>
					<view class="productcont">
						<text class="producttile">官方白皮书</text><br />
						<text class="marginleft10">Third Credit坚信信用是一座永不枯竭金库，拥有信用就等于拥有财富！</text>
					</view>

				</view>
			</uni-col>

			<uni-col :span="5" style="margin-top: 10%;">
				<text>
					<image src="/static/image/index/index-product.png" style="width: 50px;height: 50px;"></image>
				</text>
			</uni-col>
		</uni-row>

		
        <tab-bar :selected="0"></tab-bar>
	</view>
</template>


<script>
	export default {
		data() {
			return {
				rotation: [{
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
				],
				enrotation: [{
						id: 1,
						url: '/static/image/lben/lb1.png'
					},
					{
						id: 2,
						url: '/static/image/lben/lb2.png'
					},
					{
						id: 3,
						url: '/static/image/lben/lb3.png'
					},
					{
						id: 4,
						url: '/static/image/lben/lb4.png'
					}
				]
			}
		},

	}
</script>

<style lang="scss" scoped>
	image {
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

	.demo-uni-col-anniu {
		margin-top: 7px;
		height: 70px;

	}

	.demo-uni-col-anniu1 {
		margin-top: 15px;
		height: 120px;

	}

	.radios {
		border-radius: 9px;
		;
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

	.how-num {
		width: 20px;
		height: 20px;
		border-radius: 100px;
		text-align: center;
		line-height: 20px;
		font-size: 13px;
	}

	.bg-primary {
		background-color: #00875a;
		color: #fff;
	}

	.topview {
		user-select: none;
		width: 100%;
		height: 100%;
	}

	.created {
		padding-top: 2%;
		padding-left: 2%;
		font-weight: 600;
		font-size: 21px;
	}

	.titlecom {
		padding-top: 2%;
		padding-left: 2%;
		font-weight: 600;
		font-size: 17px;
		padding-bottom: 2%;
	}

	.product {
		border: 1px solid darkgray;
		width: 97%;
	}

	.productval {
		float: left;
		margin-top: 8%;
		background-color: #00875a;
		border-radius: 50%;
		width: 20px;
		font-size: 20px;
		text-align: center;
		color: wheat;
	}

	.productcont {
		argin-left: 10px;
		margin-top: 10%;
	}

	.producttile {
		font-size: 20px;
		margin-left: 10px;
	}

	.marginleft10 {
		margin-left: 10px;
	}
</style>
