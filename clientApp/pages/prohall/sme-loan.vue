<template>
	<navigation-bar :title="$t('semloan.title')"></navigation-bar>
	<app-content-view style="width: 96%;margin-left: 2%;" :show-tab-bar="true" :show-navigation-bar="false">

		<view>
			<uni-card class="box-card">
				<view>
					<text><span>SME Loans - Week</span></text>
				</view>
				<uni-row :gutter="20" style="margin-top: 15px;font-size: 15px">
					<uni-col :span="18">
						<span>{{$t('semloan.UnitPrice')}}</span>
					</uni-col>
					<uni-col :span="4">
						<text style="margin-right: 5px;"><span>$100.00</span></text>
					</uni-col>
				</uni-row>

				<uni-row :gutter="20" style="margin-top: 15px;font-size: 15px">
					<uni-col :span="18">
						<span>{{$t('semloan.Minimum')}}</span>
					</uni-col>
					<uni-col :span="4">
						<text style="text-align: right;"><span>1份</span></text>
					</uni-col>
				</uni-row>

				<uni-row :gutter="20" style="margin-top: 15px;font-size: 15px">
					<uni-col :span="18">
						<span>{{$t('semloan.cycle')}}</span>
					</uni-col>
					<uni-col :span="4">
						<text style="margin-right: 5px;"><span>7天</span></text>
					</uni-col>
				</uni-row>

				<uni-row :gutter="20" style="margin-top: 15px;font-size: 15px">
					<uni-col :span="18">
						<span>{{$t('semloan.returnrate')}}</span>
					</uni-col>
					<uni-col :span="4">
						<text style="margin-right: 5px;"><span>1.00%</span></text>
					</uni-col>
				</uni-row>

				<uni-row :gutter="20" style="margin-top: 15px;font-size: 15px">
					<uni-col :span="18">
						<span>{{$t('semloan.buymum')}}</span>
					</uni-col>
					<uni-col :span="6">

					</uni-col>
				</uni-row>

				<uni-row :gutter="20" style="margin-top: 15px;font-size: 15px">
					<uni-col :span="18">
						<span>{{$t('semloan.buyprice')}}</span>
					</uni-col>
					<uni-col :span="6">
						<text>$100.00</text>
						<text>≈ 3556.49THB </text>
					</uni-col>
				</uni-row>
				<view style="margin-top: 15px;font-size: 15px">
					<button class="btn-task">
						<!---->
						<text class="text-small text-white"><span>{{$t('semloan.button')}}</span></text>
					</button>
				</view>
			</uni-card>

			<uni-card class="box-card">
				<view class="margin-top-xl card-content-secondary">
					<view>
						<text class="text-bold text-lg"><span>{{$t('chaka.Procontent')}}</span></text>
					</view>
					<text class=" margin-top text-sm line-height-16">
						<span>
							Personal credit card repayment" products are divided into special areas
							for bad debt processing, small-amount repayment area, general repayment
							area, high-amount repayment area and large-amount repayment area. Users can
							enter to check the card and make repayment, and the area that has not
							reached the amount is grayed out and cannot be entered. The amount of the
							repayment products that do not use the special area is different, and the
							commission rate paid by the platform is also different. All users in the bad
							debt processing area can enter and check the card, but the platform account
							wallet has no balance and cannot continue the repayment task.</span>
					</text>
				</view>

			</uni-card>
		</view>

	</app-content-view>
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
	.btn-task {
		height: 33px;
		line-height: 33px;
		text-align: center;
		border-radius: 10px;
		min-width: 100px;
		color: #fff;
		font-size: 14px;
		background: linear-gradient(270deg, #108d62, #54b78d);
	}

	.button {
		position: relative;
		display: block;
		margin-left: auto;
		margin-right: auto;
		padding-left: 14px;
		padding-right: 14px;
		box-sizing: border-box;
		font-size: 18px;
		text-align: center;
		text-decoration: none;
		line-height: 2.55555556;
		border-radius: 5px;
		-webkit-tap-highlight-color: transparent;
		overflow: hidden;
		color: #000;
		background-color: #f8f8f8;
		cursor: pointer;
	}

	.lines-white {
		color: #fff;
	}

	.text-small {
		font-size: 14px;
	}
</style>
