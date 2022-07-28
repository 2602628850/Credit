<template>
	<!--信用等级管理-->
	<el-space wrap class="w100" id="search-info">
		<el-space class="search-input">
			<!-- <div>团队等级</div>
			<el-input v-model="levelName"></el-input> -->
		</el-space>
	</el-space>
	<!--信用等级管理--> 
	<div class="w100 mgt flex-row-between" id="search-button">
		<el-button type="primary" @click="loadData(1)" style="display:none;" >查询</el-button>
		<el-button type="primary" @click="addItem">添加</el-button>
	</div>
	<el-table v-loading="loading" class="mgt w100" stripe :data="tableData" style="flex: 1" border :height="contentHeight">
		<el-table-column prop="id" label="Id" width="200" align="center"></el-table-column>
		
		<el-table-column prop="hierarchy" label="利润层级" width="200" align="center"></el-table-column>
		<el-table-column prop="buyProfitRate" label="利润比例" width="200" align="center"></el-table-column>
    <el-table-column prop="" label="操作" align="center" width="200">
			<template #default="scope">
				<el-space>
					<el-button type="primary" size="small" plain @click="updItem(scope.row)">修改</el-button>
					<el-button type="danger" size="small" plain @click="delItem(scope.row)">删除</el-button>
				</el-space>
			</template>
		</el-table-column>
	</el-table>
	<!--	</div>-->
	<div class="w100 flex-row-end mgt" id="page">
		<el-pagination background layout="prev, pager, next" @current-change="currentPage" :total="total" :page-size="pageSize"/>
	</div>
	<el-dialog v-model="windowStatus" v-loading="windowSaving" width="600px">
		<el-space direction="vertical">
			<el-space>
				<div class="in-title">利润层级:</div>
				<el-input class="in-input" v-model="editItem.hierarchy"></el-input>
			</el-space>
			<el-space>
				<div class="in-title">利润比例：</div>
				<el-input class="in-input" v-model="editItem.buyProfitRate"></el-input>
			</el-space>
			<el-space>
				<el-button type="primary" @click="saveItem">保存</el-button>
			</el-space>
		</el-space>
	</el-dialog>
</template>

<script>
	export default {
		name: "teamProfit-manager",
		beforeRouteEnter(to, from, next) {
			next(vm => {
				vm.getTableHeight();
				vm.loadData(1)
			})
		},
		data() {
			return { 
				contentHeight: '0px',
				pageIndex: 1,
				pageSize: 20,
				total: 0,
				tableData: [],
				loading: false,
				windowStatus: false,
				editItem: {},
				windowSaving: false,
			}
		},
	components: {
  },
		methods: {
				currentPage(pageindex){
          this.loadData(pageindex)
				},
			delItem(item) {
				this.$msgbox({
					title: '提示',
					message: '确认删除?',
					showCancelButton: true,
					beforeClose: (action,instance,done) => {
						if (action == 'confirm') {
							this.loading = true;
							this.$Http.post('AdminTeam/TeamProfitDelete', {Id: item.id}).then(() => {
								this.loadData();
								done();
							}).catch(res => {
								this.$message.error(res.data.message);
								this.loading = false;
							})
						} else {
							done();
						}
					}
				})

			},
			saveItem() {
				this.windowSaving = true;
				if (this.editItem.id) {
					this.$Http.post('AdminTeam/TeamProfitUpdate', this.editItem).then(() => {
						this.windowStatus = false;
						this.loadData()
					}).catch(res => {
						this.windowSaving = false;
						this.$message.error(res.data.message)
					})
				} else {
					this.$Http.post('AdminTeam/TeamProfitCreate', this.editItem).then(() => {
						this.windowStatus = false;
						this.loadData()
					}).catch(res => {
						this.windowSaving = false;
						this.$message.error(res.data.message)
					})
				}

			},
			addItem() {
				this.editItem = {};
				this.windowStatus = true;
				this.windowSaving = false;
        this.editItem.isEnable ='1';
			},
			updItem(item) {
				this.windowStatus = true;
				this.windowSaving = false;
				this.editItem = JSON.parse(JSON.stringify(item)); 
				
			},
			getTime(time) {
				return this.$DateUtil.formatUnix(time / 1000);
			},
			getTableHeight() {
				this.$nextTick(() => {
					let searchInfo = document.getElementById('search-info');
					let searchButton = document.getElementById('search-button');
					let page = document.getElementById('page');

					let height = searchInfo.offsetHeight + searchButton.offsetHeight + page.offsetHeight + 24 + 'px';

					this.contentHeight = 'calc(100% - ' + height + ')'
				})
			},

			loadData(page) {
				let param = {}; 
				if (page) {
					this.pageIndex = page-1;
				}
				param.pageIndex = this.pageIndex;
				param.pageSize = this.pageSize;
				this.loading = true;
				this.$Http.get('AdminTeam/GetTeamProfitPagedList', {params: param}).then(res => {
				
					this.tableData = res.data.data.items;
					this.total = parseInt(res.data.data.totalCount);
					this.loading = false;
				}).catch((res) => {
					this.$message.error(res.data.data.message);
					this.loading = false;
				})
			}
		}
	}
</script>

<style scoped>
	@import "/src/commcss/flex.css";
	@import "/src/commcss/background.css";

</style>