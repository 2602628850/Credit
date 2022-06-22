<template>
<!--内容显示视图-->
<!--	规定tabbar高度 49  naviBar 高度 49-->
	<scroll-view scroll-y="true" :style="loadContentHeight()">
		<slot></slot>
	</scroll-view>
</template>

<script>
	export default {
		name: "app-content-view",
		props: {
			// 是否显示底部Tabbar
			showTabBar: {
				type: Boolean,
				default: false
			},
			showNavigationBar: {
				type: Boolean,
				default: false
			}
		},
		data() {
			return {
				contentHeight: {}
			}
		},
		created() {
			this.loadContentHeight();
		},
		watch: {
			showTabBar() {
				// 底部显示状态发生改变
				this.loadContentHeight();
			}
		},
		methods: {
			loadContentHeight() {
				if (this.showTabBar || this.showNavigationBar) {
					let height = 0;
					if (this.showTabBar) {
						height += 49;
					}
					if (this.showNavigationBar) {
						height += 49;
					}
					height += (this.$safeTop + this.$safeBottom);

					height += 'px';
					return {
						height: 'calc(100vh - '+height+')'
					}
				} else {
					return {
						height: '100vh'
					}
				}
			}
		}
	}
</script>

<style scoped>

</style>