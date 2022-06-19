<template>
	<view class="pagebackground">
		<navigation-bar title="积分中心"></navigation-bar>
		<view class="uni-padding-wrap uni-common-mt">

			<view class="uni-flex uni-row radios relcount iteralheight">
				<view class="text" style="width: 200rpx;margin-top: 3%;margin-left: 2%;">
					<text style="display: flex;">当前积分</text>
					<text style="color: green;font-size: 20px;">0</text>
				</view>
				<view class="text" style="-webkit-flex: 1;flex: 1;margin-top: 10%;margin-left: 50%;">
					<text class="g-icons"></text>
				</view>
			</view>

			<view class="uni-flex uni-row radios relcount iteralorder" style="margin-top: 5%;">
				<view class="text" style="margin-top: 3%;margin-left: 2%;">
					<text style="float: left;">
						<image src="/static/image/iteral/integral-mall.png" style="width: 30px;height: 30px;"></image>
					</text>
					<text style="margin-left: 5px;">积分商城</text>
				</view>
				<view class="text" style="-webkit-flex: 1;flex: 1;margin-top: 4%;margin-left: 50%;">
					<text class="g-icons"></text>
				</view>
			</view>
			<view class="uni-flex uni-row radios relcount iteralorder">
				<view class="text" style="margin-top: 3%;margin-left: 2%;">
					<text style="float: left;">
						<image src="/static/image/iteral/integral-order.png" style="width: 30px;height: 30px;"></image>
					</text>
					<text style="margin-left: 5px;">积分订单</text>
				</view>
				<view class="text" style="-webkit-flex: 1;flex: 1;margin-top: 4%;margin-left: 50%;">
					<text class="g-icons"></text>
				</view>
			</view>


			<view class="uni-flex uni-row radios relcount iteralcomplete" style="margin-top: 5%;">
				<view class="text" style="margin-top: 3%;margin-left: 2%;">
					<text style="float: left;display: flex;">
						<image src="/static/image/iteral/integral-credit.png"
							style="width: 30px;height: 30px;margin-top: 50%;"></image>
					</text>
					<text style="display:flex;margin-top:10%;width: 100px;font-weight: 600;margin-left: 20%;">完成查卡</text>
					<text style="display: flex;width: 190px;font-size: 15px;">完成一次查卡自动获得1积分</text>
				</view>
				<view class="text" style="-webkit-flex: 1;flex: 1;margin-top: 7%;margin-left: 13%;">
					<text><button class="mini-btn " type="primary" size="mini">去完成</button></text>
				</view>
			</view>
			<view class="uni-flex uni-row radios relcount iteralcomplete">
				<view class="text" style="margin-top: 3%;margin-left: 2%;">
					<text style="float: left;display: flex;">
						<image src="/static/image/iteral/integral-repayment.png"
							style="width: 30px;height: 30px;margin-top: 50%;"></image>
					</text>
					<text style="display:flex;margin-top:10%;width: 100px;font-weight: 600;margin-left: 20%;">完成代还</text>
					<text style="display: flex;width: 190px;font-size: 15px;">完成一次代还贷款自动获得20积分</text>
				</view>
				<view class="text" style="-webkit-flex: 1;flex: 1;margin-top: 7%;margin-left: 13%;">
					<text><button class="mini-btn " type="primary" size="mini">去完成</button></text>
				</view>
			</view>
			<view class="uni-flex uni-row radios relcount iteralcomplete">
				<view class="text" style="margin-top: 3%;margin-left: 2%;">
					<text style="float: left;display: flex;">
						<image src="/static/image/iteral/integral-share.png"
							style="width: 30px;height: 30px;margin-top: 50%;"></image>
					</text>
					<text style="display:flex;margin-top:10%;width: 100px;font-weight: 600;margin-left: 20%;">邀请好友</text>
					<text style="display: flex;width: 190px;font-size: 15px;">成功邀请一名好友成为平台正式会员自动获得100积分</text>
				</view>
				<view class="text" style="-webkit-flex: 1;flex: 1;margin-top: 7%;margin-left: 13%;">
					<text><button class="mini-btn " type="primary" size="mini">去完成</button></text>
				</view>
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

	.iteralheight {
		height: 6em;
	}

	.iteralorder {
		height: 3.5em;
	}

	.iteralcomplete {
		height: 5.5em;
	}

	.relcount {
		/* border: 1px solid darkgray; */
		border-width: 0 0 0 0;
		border-style: solid;
		border-color: darkgray;
		background-color: white;
	}

	.radios {
		border-radius: 9px;
	}
</style>
