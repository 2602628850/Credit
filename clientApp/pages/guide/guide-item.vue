<template>
<!--引导组件-->
	<view class="h100 w100 flex-column-center">
		<image :src="src" fit="fill" class="guide-img"></image>
		<view class="flex-row-start w100 mgt">
			<view class="flex-column-start" style="height: 100%">
				<image class="guide-tip-img" style="" fit="fill" src="/static/Icons/guide/top-left.png"></image>
			</view>
			<view class="flex-row-center guide-title text-primary">{{title}}</view>
			<view class="flex-column-end" style="height: 100%">
				<image class="guide-tip-img" style="" fit="fill" src="/static/Icons/guide/bottom-right.png"></image>
			</view>
		</view>
		<view class="flex-row-end mgt w100">
			<view class="guide-line"></view>
			<view class="guide-sub-title">{{subTitle}}</view>
		</view>
	</view>
</template>

<script>
	export default {
		name: "guide-item",
		props: {
			src: {
				type: String,
				default: ''
			},
			title: {
				type: String,
				default: ''
			},
			subTitle: {
				type: String,
				default: ''
			}
		}
	}
</script>

<style scoped>
	.guide-img {
		width: 200px;
		height: 200px;
	}
	.guide-tip-img {
		width: 17px;
		height: 17px;
	}
	.guide-title {
		font-size: 24px;
		margin: 3px -8px;
	}
	.guide-sub-title {
		font-size: 14px;
		color: #999;
		padding: 0 15px;
	}
	.guide-line {
		width: 69px;
		height: 1px;
		background: #999;
	}
</style>