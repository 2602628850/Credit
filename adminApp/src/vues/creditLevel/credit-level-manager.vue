<template>
	<!--信用等级管理-->
	<el-space wrap class="w100" id="search-info">
		<el-space class="search-input">
			<div>等级名称</div>
			<el-input v-model="levelName"></el-input>
		</el-space>
	</el-space>
	<div class="w100 mgt flex-row-between" id="search-button">
		<el-button type="primary" @click="loadData(1)">查询</el-button>
		<el-button type="primary" @click="addItem">添加</el-button>
	</div>
	<!--	<div :style="{height: contentHeight}">-->
	<el-table v-loading="loading" class="mgt w100" stripe :data="tableData" style="flex: 1" border :height="contentHeight">
		<el-table-column prop="id" label="ID" width="200" align="center"></el-table-column>
		<el-table-column prop="levelName" label="等级名称" width="200" align="center"></el-table-column>
		<el-table-column prop="creditValue" label="等级信用值" width="200" align="center"></el-table-column>
		<el-table-column prop="levelSort" label="序号" width="200" align="center"></el-table-column>
		<el-table-column prop="chakaNum" label="查卡次数" width="200" align="center"></el-table-column>
		<el-table-column prop="profit" label="收益比例(%)" width="200" align="center"></el-table-column>
		<el-table-column prop="createAt" label="创建时间" width="200" align="center">
			<template #default="scope">
				{{ getTime(scope.row.createAt) }}
			</template>
		</el-table-column>
		<el-table-column prop="" label="操作" align="center" width="130">
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
				<div class="in-title">等级名称</div>
				<el-input class="in-input" v-model="editItem.levelName"></el-input>
			</el-space>
			<el-space>
				<div class="in-title">等级信用值</div>
				<el-input class="in-input" v-model="editItem.creditValue"></el-input>
			</el-space>
			<el-space>
				<div class="in-title">序号</div>
				<el-input class="in-input" v-model="editItem.levelSort"></el-input>
			</el-space>
			<el-space>
				<div class="in-title">查卡次数</div>
				<el-input class="in-input" v-model="editItem.chakaNum"></el-input>
			</el-space>
			<el-space>
				<div class="in-title">收益比例</div>
				<el-input class="in-input" v-model="editItem.profit">
					<template #append>%</template>
				</el-input>
			</el-space>
			<el-space>
				<el-button type="primary" @click="saveItem">保存</el-button>
			</el-space>
		</el-space>
	</el-dialog>
</template>

<script>
	export default {
		name: "credit-level-manager",
		beforeRouteEnter(to, from, next) {
			next(vm => {
				vm.getTableHeight();
				vm.loadData(1)
			})
		},
		data() {
			return {
				levelName: '',

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
		methods: {
				currentPage(pageindex){
          this.loadData(pageindex)
				},
			delItem(item) {
				this.$msgbox({
					title: '提示',
					message: '确认删除' + item.levelName + '?',
					showCancelButton: true,
					beforeClose: (action,instance,done) => {
						if (action == 'confirm') {
							this.loading = true;
							this.$Http.post('AdminCreditLevel/CreditLevelDelete', {id: item.id}).then(() => {
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
				// this.$alert('确认删除'+item.levelName+'?','提示',(action)=>{
				// 	if (action == 'confirm') {
				// 		this.loading = true;
				// 		this.$Http.post('AdminCreditLevel/CreditLevelDelete',{id:item.id}).then(()=>{
				// 			this.loadData();
				// 		}).catch(res=>{
				// 			this.$message.error(res.data.message);
				// 			this.loading = false;
				// 		})
				// 	}
				// })
			},
			saveItem() {
				if (!this.editItem.levelName) {
					this.$message.error('请输入等级名称');
					return;
				}
				if (!this.editItem.creditValue) {
					this.$message.error('请输入等级信用值');
					return;
				}
				if (this.$ObjectUtil.isEmpty(this.editItem.levelSort)) {
					this.$message.error('请输入序号');
					return;
				}
				if (!this.editItem.chakaNum) {
					this.$message.error('请输入查卡次数');
					return;
				}
				if (!this.editItem.profit) {
					this.$message.error('请输入收益比例');
					return;
				}

				this.windowSaving = true;
				if (this.editItem.id) {
					this.$Http.post('AdminCreditLevel/CreditLevelUpdate', this.editItem).then(() => {
						this.windowStatus = false;
						this.loadData()
					}).catch(res => {
						this.windowSaving = false;
						this.$message.error(res.data.message)
					})
				} else {
					this.$Http.post('AdminCreditLevel/CreditLevelCreate', this.editItem).then(() => {
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
				if (this.levelName) {
					param.levelName = this.levelName;
				}
				if (page) {
					this.pageIndex = page;
				}
				param.pageIndex = this.pageIndex;
				param.pageSize = this.pageSize;
				this.loading = true;
				this.$Http.get('AdminCreditLevel/GetCreditLevelPagedList', {params: param}).then(res => {
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