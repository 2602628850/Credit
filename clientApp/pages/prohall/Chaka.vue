<template>
	<navigation-bar :title="$t('chaka.title')"></navigation-bar>
	<view>
		<view class="page">
			<view class="card-page-place"></view>
			<view class="page-card">
				<view class="card-page margin-top">
					<view class="credit-card position-relative">
						<image class="card-bg position-absolute" src="/static/image/hall/product-info-credit.png">
						</image>
						<view class="credit-info position-relative flex-1 justify-between">
							<view class="flex-row justify-between">
								<view>
									<text class="text-white text-lg text-bold">
										<span>CREDIT</span></text>
								</view>
								<view class="level-icon">
									<text class="font-italic text-bold text-white">
										<span>V0</span></text>
								</view>
							</view>
							<view>
								<text class="card-num"><span>**** **** ****
										****</span></text>
							</view>
							<view class="flex-row justify-between">
								<view>
									<text class="text-white text-xs"><span>{{$t('chaka.bankname')}}</span>
									</text>
									<text class="text-white text-small text-bold">
										<span>****</span></text>
								</view>
								<view  class="align-flex-end">
									<text  class="text-white text-xs"><span>{{$t('chaka.repayment')}}</span></text>
									<text  class="credit-amount text-small text-bold">
										<span>$17.60</span></text>
								</view>
								<!---->
							</view>
						</view>
					</view>
					<view class="margin-top-lg">
						<view>
							<view class="flex-row align-center flex-1">
								<text class="text-small"><span>{{$t('chaka.todayCheckNum')}}:</span>
								</text>
								<text class="text-small text-bold text-primary margin-left-xs"><span>3</span>
								</text>
							</view>
							<view class="margin-top">
								<text class="btn-search"><span>{{$t('chaka.checkButton')}}</span></text>
							</view>
						</view>
					</view>
					<!---->
					<view id="cardList" class="margin-top-lg card-content-secondary">
						<view>
							<text class="text-bold text-lg"><span>{{$t('chaka.selectrepayment')}}</span></text>
						</view>
						<view class="card-content-sm flex-row align-center margin-top card-select">
							<view class="flex-1">
								<text class="text-sm"><span>洪仁峰</span></text>
								<text class="text-xs text-secondary">
									<span>****62930515****</span></text>
							</view>
							<text class="text-lg"><span>$17.40</span></text>
						</view>
						<view class="card-content-sm flex-row align-center margin-top">
							<view class="flex-1">
								<text class="text-sm"><span>袁怡芳</span></text>
								<text class="text-xs text-secondary">
									<span>****01785323****</span></text>
							</view>
							<text class="text-lg"><span>$16.20</span></text>
						</view>
						<view class="card-content-sm flex-row align-center margin-top">
							<view class="flex-1">
								<text class="text-sm"><span>Huang Yude</span></text>
								<text class="text-xs text-secondary">
									<span>****09798794****</span></text>
							</view>
							<text class="text-lg"><span>$17.60</span></text>
						</view>
					</view>
					<!---->
					<view class="margin-top-lg card-content-secondary">
						<view>
							<text class="text-bold text-lg"><span>{{$t('chaka.repayment')}}</span></text>
						</view>
						<view class="align-center margin-top-sm">
							<text class="text-21"><span>$17.60</span></text>
							<text class="text-xxs margin-top-xs"><span>≈ 621.17THB</span>
							</text>
						</view>
						<view class="flex-row margin-top">
							<button class="flex-1 btn-primary">{{$t('chaka.behalfButton')}}</button>
						</view>
					</view>
					<view class="margin-top-xl card-content-secondary">
						<view>
							<text class="text-bold text-lg"><span>{{$t('chaka.todayCheck')}}</span>
							</text>
							<!---->
						</view>
						<view class="flex-row margin-top">
							<view class="flex-1">
								<text class="text-bold text-primary text-21">
									<span>0</span></text>
								<text class="text-xs text-secondary margin-top-xs">
									<span>{{$t('chaka.Tocheck')}}</span></text>
							</view>
							<view class="flex-1">
								<text class="text-bold text-primary text-21">
									<span>$0</span></text>
								<text class="text-xs text-secondary margin-top-xs">
									<span>{{$t('chaka.Tocheckprofit')}}</span></text>
							</view>
						</view>
					</view>
					<view class="margin-top-xl card-content-secondary">
						<text class="text-bold text-lg"><span>{{$t('chaka.Procontent')}}</span></text>
						<text class=" margin-top text-sm line-height-16">
							<span>"Personal credit card repayment" products are divided into special areas
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
				</view>
				<view class="margin"></view>
			</view>
			<view>
				<!---->
			</view>
		</view>
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
	.page {
		position: relative;
	}

	view {
		display: flex;
		flex-direction: column;
	}

	view {
		font-size: 15px;
		overflow-wrap: anywhere;
	}

	.card-page-place {
		position: absolute;
		height: 300px;
		left: 0;
		right: 0;
		top: 0;
		background-color: #f4f5f7;
	}

	.page-card {
		background-color: #fff;
		margin-top: 15px;
		border-top-left-radius: 30px;
		border-top-right-radius: 30px;
		position: relative;
	}

	.card-page {
		padding: 0 19px;
	}

	.margin-top {
		margin-top: 15px;
	}

	.credit-card {
		height: 265px;
	}

	.position-relative {
		position: relative !important;
	}

	.card-bg {
		width: 457px;
		height: 265px;
		top: 0;
		left: 0;
	}

	.position-absolute {
		position: absolute !important;
	}

	.credit-info {
		padding: 25px 20px;
	}

	.justify-between {
		justify-content: space-between !important;
	}

	.flex-1 {
		flex: 1;
		flex-grow: 1 !important;
		flex-basis: 0 !important;
	}

	.position-relative {
		position: relative !important;
	}

	.justify-between {
		justify-content: space-between !important;
	}

	.flex-row {
		flex-direction: row !important;
	}

	.text-white,
	.line-white,
	.lines-white {
		color: #fff;
	}

	.text-lg {
		font-size: 16px;
	}

	.text-bold {
		font-weight: 700;
		-webkit-font-smoothing: auto;
	}

	* {
		margin: 0;
		-webkit-tap-highlight-color: transparent;
	}

	.level-icon {
		width: 30px;
		height: 30px;
		line-height: 30px;
		text-align: center;
		border-radius: 30px;
		border: 1px solid #98d4af;
	}

	.font-italic {
		font-style: italic;
	}

	.text-white,
	.line-white,
	.lines-white {
		color: #fff;
	}

	.text-bold {
		font-weight: 700;
		-webkit-font-smoothing: auto;
	}

	.card-num {
		letter-spacing: 2px;
		font-size: 20px;
		color: #fff;
	}

	.justify-between {
		justify-content: space-between !important;
	}

	.flex-row {
		flex-direction: row !important;
	}

	.text-white,
	.line-white,
	.lines-white {
		color: #fff;
	}

	.text-xs {
		font-size: 12px;
	}

	.text-white,
	.line-white,
	.lines-white {
		color: #fff;
	}

	.text-small {
		font-size: 14px;
	}

	.text-bold {
		font-weight: 700;
		-webkit-font-smoothing: auto;
	}

	.margin-top-lg {
		margin-top: 20px;
	}

	view {
		display: flex;
		flex-direction: column;
	}

	.align-center {
		align-items: center !important;
	}

	.flex-1 {
		flex: 1;
		flex-grow: 1 !important;
		flex-basis: 0 !important;
	}

	.flex-row {
		flex-direction: row !important;
	}

	.text-small {
		font-size: 14px;
	}

	.text-primary {
		color: #00875a;
	}

	.text-small {
		font-size: 14px;
	}

	.text-bold {
		font-weight: 700;
		-webkit-font-smoothing: auto;
	}

	.margin-left-xs {
		margin-left: 6px;
	}

	.margin-top {
		margin-top: 15px;
	}

	.btn-search {
		background: linear-gradient(270deg, #54b78d, #85d49d);
		height: 44px;
		line-height: 44px;
		text-align: center;
		font-size: 14px;
		font-weight: 700;
		color: #fff;
		padding: 0 20px;
		border-radius: 15px;
	}

	.card-content-secondary {
		border-radius: 15px;
		background-color: #f4f5f7;
		padding: 20px;
	}

	.margin-top-xl {
		margin-top: 25px;
	}

	.text-lg {
		font-size: 16px;
	}

	.text-bold {
		font-weight: 700;
		-webkit-font-smoothing: auto;
	}

	image>img {
		-webkit-user-select: none;
		display: block;
		position: absolute;
		top: 0;
		left: 0;
		opacity: 0;
	}

	image>div,
	image>img {
		width: 100%;
		height: 100%;
	}

	.card-content-secondary {
		border-radius: 15px;
		background-color: #f4f5f7;
		padding: 20px;
	}

	.margin-top-lg {
		margin-top: 20px;
	}

	.card-content-sm {
		border-radius: 15px;
		background-color: #fff;
		padding: 15px;
	}

	.margin-top {
		margin-top: 15px;
	}

	.align-center {
		align-items: center !important;
	}

	.flex-row {
		flex-direction: row !important;
	}

	.card-select {
		border: 1px solid #00875a;
	}

	.card-content-secondary {
		border-radius: 15px;
		background-color: #f4f5f7;
		padding: 20px;
	}

	.margin-top-lg {
		margin-top: 20px;
	}

	.text-lg {
		font-size: 16px;
	}

	.text-bold {
		font-weight: 700;
		-webkit-font-smoothing: auto;
	}

	.text-21 {
		font-size: 21px;
	}

	.text-xxs {
		font-size: 11px;
	}

	.margin-top-xs {
		margin-top: 5px;
	}

	.btn-primary {
		background-color: #00875a;
		border: 1px solid #00875a !important;
		color: #fff !important;
		border-radius: 15px;
		font-size: 15px;
		height: 44px;
		line-height: 44px;
	}

	.flex-1 {
		flex: 1;
		flex-grow: 1 !important;
		flex-basis: 0 !important;
	}

	button {
		position: relative;
		display: block;
		margin-left: auto;
		margin-right: auto;
		padding-left: 14px;
		padding-right: 14px;
		box-sizing: border-box;
		text-align: center;
		text-decoration: none;
		-webkit-tap-highlight-color: transparent;
		overflow: hidden;
		cursor: pointer;
	}
	.credit-amount {
    color: #fdd741;
}
</style>
