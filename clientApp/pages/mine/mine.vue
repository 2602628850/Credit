<template>
<!--我的-->
	<app-content-view :show-tab-bar="true">
		<navigation-bar :title="$t('mine.title')"></navigation-bar>
	</app-content-view>
	<bottomhand :selected="4"></bottomhand>
</template>

<script>
	import NavigationBar from "../../components/navigation-bar";
	import AppContentView from "../../components/app-content-view";
	import Bottomhand from "../../components/bottomhand";
	export default {
		name: "mine",
		components: {Bottomhand, AppContentView, NavigationBar},
	}
</script>

<style scoped>

</style>