<template>
	<view :style="{height: statusBarHeight}"></view>
	<view class="flex-row-between navi" :style="{color: titleColor}">
		<view class="h100 flex-row-start">
			<image class="navi-logo mgl" fit="fill" :src="'/static/logo.png'"></image>
			<view class="mgl">{{ $Const.APP_NAME }}</view>
		</view>
		<view class="h100 flex-row-end mgr">
			<view class="flex-row-start mgr">
				<view class="navi-icon mgr iconfont icon-diqiu"></view>
				<picker :range="langList" :index="langIndex" range-key="name" @change="indexChange">
					<view>{{ langList[langIndex].name }}</view>
				</picker>
			</view>
			<view class="navi-icon iconfont icon-wodekefu" @click="toServer"></view>
		</view>
	</view>
</template>

<script>

	import i18n from "../i18n";
	import * as storeUtil from "../common/js/Utils/StoreUtil";

	export default {
		name: "navigation-bar",
		props: {
			titleColor: {
				type: String,
				default: 'white'
			},
		},
		data() {
			return {
				langList: [],
				lang: '',
				langIndex: '',
				statusBarHeight: '0px',
			}
		},
		methods: {
			indexChange(e) {
				this.langIndex = e.detail.value;
				this.lang = this.langList[this.langIndex].value;

				this.$i18n.locale = this.lang;
				this.$StoreUtil.set('lang', this.lang);
			},
			toServer() {
				console.log('to Server')
			}
		},
		created() {
			this.langList = this.$LangUtil.getLangList();
			this.lang = this.$LangUtil.getLang();
			for (let i = 0; i < this.langList.length; i++) {
				let item = this.langList[i];
				if (item.value == this.lang) {
					this.langIndex = i;
					break;
				}
			}
			this.statusBarHeight = this.$safeTop;
			if (this.statusBarHeight <= 0) {
				this.statusBarHeight = 0;
			}
			this.statusBarHeight += 'px';
		}
	}
</script>

<style scoped>
	.navi {
		height: 49px;
	}

	.navi-logo {
		height: 30px;
		width: 30px;
		color: white;
	}

	.navi-icon {
		font-size: 20px;
	}
</style>