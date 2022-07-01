<template>
	<navigation-bar :title="$t('Temrule.title')"></navigation-bar>
	<app-content-view :show-tab-bar="false" :show-navigation-bar="true">
		<view>
			<view   class="page">
				<view   class="card-page margin-top">
					<text >
						<view  style="position: relative;">
							<p><b>团队模式</b><b></b></p>
							<p><br></p>
							<p>每月月末根据团队当月的还款总金额领取分红（统计到ABCDE共5级下级团队）</p>
							<p>每成功邀请1名直属下级，赠送100商城积分</p>
							<p>3天内有完成一次平台任务或正在进行任务下级方可加入团队人数统计</p>
							<p><b></b></p>
							<p><b>初级代理</b><b></b></p>
							<p>Ø 成功邀请3名下级成为平台初级用户</p>
							<p>Ø 每个月可以领取分红—0.01%团队还款总金额</p>
							<p>Ø 下级购买SME Loans收益的8%</p>
							<p><b>中级代理</b><b></b></p>
							<p>Ø 成功邀请20名下级成为平台初级用户</p>
							<p>Ø 每个月可以领取分红—0.015%团队还款总金额</p>
							<p>Ø 下级购买SME Loans收益的9%</p>
							<p><b></b></p>
							<p><b></b></p>
							<p><b>高级代理</b><b></b></p>
							<p>Ø 成功邀请50名下级成为平台初级用户</p>
							<p>Ø 每个月可以领取分红—0.025%团队还款总金额</p>
							<p>Ø 下级购买SME Loans收益的10%</p>
							<p><b></b></p>
							<p><b></b></p>
							<p><b>区域代理</b><b></b></p>
							<p>Ø 成功邀请200名下级成为平台初级用户</p>
							<p>Ø 每个月可以领取分红—0.035%团队还款总金额</p>
							<p>Ø 下级购买SME Loans收益的12%</p>
							<p><b></b></p>
							<p><b></b></p>
							<p><b>城市代理</b><b></b></p>
							<p>Ø 成功邀请500名下级成为平台初级用户</p>
							<p>Ø 每个月可以领取分红—0.05%团队还款总金额</p>
							<p>Ø 下级购买SME Loans收益的14%</p>
							<p><b></b></p>
							<p><b></b></p>
							<p><b>大区代理</b><b></b></p>
							<p>Ø 成功邀请1000名下级成为平台初级用户</p>
							<p>Ø 每个月可以领取分红—0.07%团队还款总金额</p>
							<p>Ø 下级购买SME Loans收益的16%</p>
							<uni-resize-sensor>
								<view >
									<view ></view >
								</view >
								<view >
									<view ></view >
								</view >
							</uni-resize-sensor>
						</view >
					</text>
				</view >
			</view >
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
.card-page {
    padding: 0 20px;
}
.margin-top {
    margin-top: 15px;
}
</style>
